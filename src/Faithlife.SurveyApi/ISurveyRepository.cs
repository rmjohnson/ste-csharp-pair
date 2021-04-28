using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Faithlife.SurveyApi
{
	public interface ISurveyRepository
	{
		Task<Survey> CreateSurveyAsync(Survey survey, CancellationToken cancellationToken);
		Task<Survey> GetSurveyById(string surveyId, CancellationToken cancellationToken);
		Task<SurveyResponse> SaveSurveyResponseAsync(SurveyResponse surveyResponse, CancellationToken cancellationToken);
		Task<SurveyResponse> GetSurveyResponseByIdAsync(string surveyResponseId, CancellationToken cancellationToken);
	}
}
