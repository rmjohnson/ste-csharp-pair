using System;

namespace Faithlife.SurveyApi
{
	public sealed class QuestionResponse
	{
		public string QuestionId { get; set; }
		public string Response { get; set; }

		public QuestionResponse Clone()
		{
			return new QuestionResponse
			{
				QuestionId = QuestionId,
				Response = Response
			};
		}
	}
}
