namespace Faithlife.SurveyApi.Data.DbObjects
{
	public sealed class DbSurveyResponse
	{
		public long Id { get; set; }
		public long SurveyId { get; set; }
		public string CustomerName { get; set; }
		public string CustomerEmail { get; set; }
	}
}