using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Facility.Core;
using Faithlife.SurveyApi.Core.Mappers;
using Faithlife.SurveyApi.v1.Client;

namespace Faithlife.SurveyApi.Core
{
	public class CoreSurveyApi : ISurveyApi
	{
		public CoreSurveyApi(ISurveyRepository repository)
		{
			m_repository = repository;
		}

		public async Task<ServiceResult<CreateSurveyResponseDto>> CreateSurveyAsync(CreateSurveyRequestDto request, CancellationToken cancellationToken)
		{
			var survey = SurveyMapper.Map(request.Survey);
			var createdSurvey = await m_repository.CreateSurveyAsync(survey, cancellationToken);
			return ServiceResult.Success(new CreateSurveyResponseDto
			{
				Survey = SurveyMapper.MapToDto(createdSurvey)
			});
		}

		public async Task<ServiceResult<SubmitSurveyResponseResponseDto>> SubmitSurveyResponseAsync(SubmitSurveyResponseRequestDto request, CancellationToken cancellationToken)
		{
			var surveyResponse = request.Response;
			if (surveyResponse.SurveyId is null)
				return ServiceResult.Failure(ServiceErrors.CreateInvalidRequest("SurveyId is required."));

			var survey = await m_repository.GetSurveyById(surveyResponse.SurveyId, cancellationToken);
			if (survey is null)
				return ServiceResult.Failure(ServiceErrors.CreateInvalidRequest("Could not survey with specified Id."));

			if (string.IsNullOrWhiteSpace(surveyResponse.CustomerName))
				return ServiceResult.Failure(ServiceErrors.CreateInvalidRequest("Customer name must be provided."));

			if (surveyResponse.CustomerName.Split(' ').Count() >= 2)
				return ServiceResult.Failure(ServiceErrors.CreateInvalidRequest("Customer name include at least first and last name."));

			if (string.IsNullOrWhiteSpace(surveyResponse.CustomerEmail))
				return ServiceResult.Failure(ServiceErrors.CreateInvalidRequest("Customer email must be provided."));

			if (!s_emailRegex.IsMatch(surveyResponse.CustomerEmail))
				return ServiceResult.Failure(ServiceErrors.CreateInvalidRequest("Customer email must be a valid email."));

			if (surveyResponse.QuestionResponses.Count == 0)
				return ServiceResult.Failure(ServiceErrors.CreateInvalidRequest("Must include at least one question response."));

			var surveyQuestionIds = survey.Questions.Select(q => q.QuestionId).ToHashSet();
			if (surveyResponse.QuestionResponses.Any(qr => !surveyQuestionIds.Contains(qr.QuestionId)))
				return ServiceResult.Failure(ServiceErrors.CreateInvalidRequest("Question IDs must match question IDs connected to the survey."));

			var responseQuestionIds = surveyResponse.QuestionResponses.Select(qr => qr.QuestionId).ToHashSet();
			if (!surveyQuestionIds.SetEquals(responseQuestionIds))
				return ServiceResult.Failure(ServiceErrors.CreateInvalidRequest("Responses to all questions on the survey must be included."));

			var savedResponse = await m_repository.SaveSurveyResponseAsync(SurveyResponseMapper.Map(request.Response), cancellationToken);

			return ServiceResult.Success(new SubmitSurveyResponseResponseDto
			{
				Response = SurveyResponseMapper.MapToDto(savedResponse)
			});
		}

		private static readonly Regex s_emailRegex = new Regex(@".*@.*\..*", RegexOptions.Singleline);

		private readonly ISurveyRepository m_repository;
	}
}
