using System;
using System.Collections.Generic;
using System.Linq;

namespace Faithlife.SurveyApi
{
	public sealed class SurveyResponse
	{
		public string Id { get; set; }
		public string SurveyId { get; set; }
		public string CustomerName { get; set; }
		public string CustomerEmail { get; set; }
		public IReadOnlyList<QuestionResponse> QuestionResponses { get; set; }

		public SurveyResponse Clone()
		{
			return new SurveyResponse
			{
				Id = Id,
				SurveyId = SurveyId,
				CustomerName = CustomerName,
				CustomerEmail = CustomerEmail,
				QuestionResponses = QuestionResponses.Select(qr => qr.Clone()).ToList(),
			};
		}
	}
}
