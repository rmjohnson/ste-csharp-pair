using System;

namespace Faithlife.SurveyApi
{
	public sealed class Question
	{
		public string QuestionId { get; set; }
		public string Prompt { get; set; }

		public Question Clone()
		{
			return new Question
			{
				QuestionId = QuestionId,
				Prompt = Prompt
			};
		}
	}
}
