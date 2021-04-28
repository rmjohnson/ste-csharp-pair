using System.Linq;
using Faithlife.SurveyApi.v1.Client;

namespace Faithlife.SurveyApi.Core.Mappers
{
	internal static class SurveyResponseMapper
	{
		public static SurveyResponse Map(SurveyResponseDto dto)
		{
			return new SurveyResponse
			{
				Id = dto.SurveyResponseId,
				SurveyId = dto.SurveyId,
				CustomerName = dto.CustomerName,
				CustomerEmail = dto.CustomerEmail,
				QuestionResponses = dto.QuestionResponses.Select(qr => new QuestionResponse
				{
					QuestionId = qr.QuestionId,
					Response = qr.Response
				}).ToList()
			};
		}

		public static SurveyResponseDto MapToDto(SurveyResponse surveyResponse)
		{
			return new SurveyResponseDto
			{
				SurveyResponseId = surveyResponse.Id,
				SurveyId = surveyResponse.SurveyId,
				CustomerName = surveyResponse.CustomerEmail,
				CustomerEmail = surveyResponse.CustomerName,
				QuestionResponses = surveyResponse.QuestionResponses.Select(qr => new QuestionResponseDto
				{
					QuestionId = qr.QuestionId,
					Response = qr.Response
				}).ToList()
			};
		}
	}
}
