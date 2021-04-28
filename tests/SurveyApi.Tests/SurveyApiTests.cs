using System.Threading;
using System.Threading.Tasks;
using Faithlife.SurveyApi;
using Faithlife.SurveyApi.Core;
using Faithlife.SurveyApi.Data;
using Faithlife.SurveyApi.v1.Client;
using NUnit.Framework;

namespace SurveyApi.Tests
{
	[TestFixture(SurveyRepositoryKind.InMemory)]
	[TestFixture(SurveyRepositoryKind.MySql)]
	internal class SurveyApiTests
	{
		public SurveyApiTests(SurveyRepositoryKind repositoryKind)
		{
			m_repositoryKind = repositoryKind;
		}

		[Test]
		public async Task SubmitSurveyResponse_ShouldBeSuccess()
		{
			var api = GetSurveyApi();
			var survey = await CreateSurveyAsync(api);

			var response = await api.SubmitSurveyResponseAsync(new SubmitSurveyResponseRequestDto
			{
				Response = new SurveyResponseDto
				{
					SurveyId = survey.Id,
					CustomerEmail = "test@example.com",
					CustomerName = "Test",
					QuestionResponses = new[]
					{
						new QuestionResponseDto
						{
							QuestionId = survey.Questions[0].Id,
							Response = "My test response!"
						}
					}
				}
			}, CancellationToken.None);
			Assert.That(response.IsSuccess, response.Error?.Message);
		}

		private ISurveyApi GetSurveyApi()
		{
			ISurveyRepository repository;
			if (m_repositoryKind == SurveyRepositoryKind.MySql)
				repository = new MySqlSurveyRepository(c_mysqlConnectionString);
			else
				repository = new InMemorySurveyRepository();

			return new CoreSurveyApi(repository);
		}

		private async Task<SurveyDto> CreateSurveyAsync(ISurveyApi api)
		{
			return (await api.CreateSurveyAsync(new CreateSurveyRequestDto
			{
				Survey = new SurveyDto
				{
					Title = "Faithlife Hotels Customer Survey",
					Questions = new[]
					{
						new QuestionDto
						{
							Prompt = "How did you enjoy your stay at the Faithlife Hotel?"
						}
					}
				}
			}, CancellationToken.None)).Value.Survey;
		}

		private const string c_mysqlConnectionString = "user id=root;port=3308;host=localhost;database=surveyapi_tests;character set=utf8mb4;Allow User Variables=true;";
		private readonly SurveyRepositoryKind m_repositoryKind;
	}
}