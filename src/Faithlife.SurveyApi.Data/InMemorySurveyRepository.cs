using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Faithlife.SurveyApi.Data
{
	public sealed class InMemorySurveyRepository : ISurveyRepository
	{

		public async Task<Survey> CreateSurveyAsync(Survey survey, CancellationToken cancellationToken)
		{
			lock (s_lock)
			{
				survey.Id = (s_surveys.Count + 1).ToString();
				s_surveys.Add(survey);
			}
			return survey.Clone();
		}

		public async Task<Survey> GetSurveyById(string surveyId, CancellationToken cancellationToken)
		{
			lock (s_lock)
				return s_surveys.SingleOrDefault(s => s.Id == surveyId)?.Clone();
		}

		public async Task<SurveyResponse> SaveSurveyResponseAsync(SurveyResponse surveyResponse, CancellationToken cancellationToken)
		{
			lock (s_lock)
			{
				surveyResponse.Id = (s_surveyResponses.Count + 1).ToString();
				s_surveyResponses.Add(surveyResponse);
			}
			return surveyResponse.Clone();
		}

		public async Task<SurveyResponse> GetSurveyResponseByIdAsync(string surveyResponseId, CancellationToken cancellationToken)
		{
			lock (s_lock)
				return s_surveyResponses.SingleOrDefault(sr => sr.Id == surveyResponseId)?.Clone();
		}

		private static object s_lock = new object();

		private static List<Survey> s_surveys = new List<Survey>();
		private static List<SurveyResponse> s_surveyResponses = new List<SurveyResponse>();
	}
}
