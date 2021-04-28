namespace Faithlife.SurveyApi.Data.DbObjects
{
	public sealed class DbQuestion
	{
		public long Id { get; set; }
		public long SurveyId { get; set; }
		public string Prompt { get; set; }
	}
}