using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Faithlife.SurveyApi.Data.DbObjects;

namespace Faithlife.SurveyApi.Data
{
	public sealed class MySqlSurveyRepository : ISurveyRepository
	{
		public MySqlSurveyRepository(string connectionString)
		{
			m_connectionFactory = new MySqlConnectionFactory(connectionString);
		}

		public async Task<Survey> CreateSurveyAsync(Survey survey, CancellationToken cancellationToken)
		{
			const string surveySql = @"
INSERT INTO surveys
(title)
VALUES
(@title);

SELECT LAST_INSERT_ID();";

			const string questionSql = @"
INSERT INTO questions
(survey_id, prompt)
VALUES
(@surveyId, @prompt)";

			using (var connection = await m_connectionFactory.OpenConnectionAsync(cancellationToken))
			{
				var surveyId = (await connection.QueryAsync<long>(surveySql, new
				{
					title = survey.Title,
				})).Single();

				foreach (var question in survey.Questions)
				{
					await connection.ExecuteAsync(questionSql, new
					{
						surveyId,
						prompt = question.Prompt
					});
				}

				return await GetSurveyById(surveyId.ToString(), cancellationToken);
			}
		}

		public async Task<Survey> GetSurveyById(string surveyId, CancellationToken cancellationToken)
		{
			const string surveySql = @"
SELECT
	id AS Id,
	title AS Title
FROM surveys
WHERE id = @surveyId;";

			const string questionsSql = @"
SELECT
	id AS Id,
	survey_id AS SurveyId,
	prompt AS Prompt
FROM questions
WHERE survey_id = @surveyId";

			using (var connection = await m_connectionFactory.OpenConnectionAsync(cancellationToken))
			{
				var survey = (await connection.QueryAsync<DbSurvey>(surveySql, new
				{
					surveyId = long.Parse(surveyId)
				})).SingleOrDefault();

				var questions = (await connection.QueryAsync<DbQuestion>(questionsSql, new
				{
					surveyId = long.Parse(surveyId)
				}));

				return MapSurvey(survey, questions);
			}
		}

		public async Task<SurveyResponse> SaveSurveyResponseAsync(SurveyResponse surveyResponse, CancellationToken cancellationToken)
		{
			const string surveyResponseSql = @"
INSERT INTO survey_responses
(survey_id, customer_name, customer_email)
VALUES
(@surveyId, @customerName, @customerEmail);

SELECT LAST_INSERT_ID();";

			const string questionResponseSql = @"
INSERT INTO question_responses
(survey_response_id, question_id, response)
VALUES
(@surveyResponseId, @questionId, @response)";

			using (var connection = await m_connectionFactory.OpenConnectionAsync(cancellationToken))
			{
				var surveyResponseId = (await connection.QueryAsync<long>(surveyResponseSql, new
				{
					surveyId = surveyResponse.SurveyId,
					customerName = surveyResponse.CustomerName,
					customerEmail = surveyResponse.CustomerEmail
				})).Single();

				foreach (var questionResponse in surveyResponse.QuestionResponses)
				{
					await connection.ExecuteAsync(questionResponseSql, new
					{
						surveyResponseId,
						questionId = questionResponse.QuestionId,
						response = questionResponse.Response
					});
				}

				return await GetSurveyResponseByIdAsync(surveyResponseId.ToString(), cancellationToken);
			}
		}

		public async Task<SurveyResponse> GetSurveyResponseByIdAsync(string surveyResponseId, CancellationToken cancellationToken)
		{
			const string surveyResponseSql = @"
SELECT
	id AS Id,
	survey_id AS SurveyId,
	customer_name AS CustomerName,
	customer_email AS CustomerEmail
FROM survey_responses
WHERE id = @surveyResponseId;";

			const string questionResponsesSql = @"
SELECT
	id AS Id,
	survey_response_id AS SurveyResponseId,
	question_id AS QuestionId,
	response AS Respons
FROM question_responses
WHERE survey_response_id = @surveyResponseId";

			using (var connection = await m_connectionFactory.OpenConnectionAsync(cancellationToken))
			{
				var surveyResponse = (await connection.QueryAsync<DbSurveyResponse>(surveyResponseSql, new
				{
					surveyResponseId = long.Parse(surveyResponseId)
				})).Single();

				var questionResponses = (await connection.QueryAsync<DbQuestionResponse>(questionResponsesSql, new
				{
					surveyResponseId = long.Parse(surveyResponseId)
				}));

				return MapSurveyResponse(surveyResponse, questionResponses);
			}
		}

		private SurveyResponse MapSurveyResponse(DbSurveyResponse surveyResponse, IEnumerable<DbQuestionResponse> questionResponses)
		{
			if (surveyResponse is null)
				return null;

			return new SurveyResponse
			{
				Id = surveyResponse.Id.ToString(),
				SurveyId = surveyResponse.SurveyId.ToString(),
				CustomerName = surveyResponse.CustomerName,
				CustomerEmail = surveyResponse.CustomerEmail,
				QuestionResponses = questionResponses.Select(qr => new QuestionResponse
				{
					QuestionId = qr.QuestionId.ToString(),
					Response = qr.Response
				}).ToList()
			};
		}

		private Survey MapSurvey(DbSurvey survey, IEnumerable<DbQuestion> questions)
		{
			if (survey is null)
				return null;

			return new Survey
			{
				Id = survey.Id.ToString(),
				Title = survey.Title,
				Questions = questions.Select(q => new Question
				{
					QuestionId = q.Id.ToString(),
					Prompt = q.Prompt
				}).ToList()
			};
		}

		private readonly MySqlConnectionFactory m_connectionFactory;
	}
}
