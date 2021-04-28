namespace Faithlife.SurveyApi.Data.DbObjects
{
	public sealed class DbQuestionResponse
	{
		public long Id { get; set; }
		public long SurveyResponseId { get; set; }
		public long QuestionId { get; set; }
		public string Response { get; set; }
	}
}