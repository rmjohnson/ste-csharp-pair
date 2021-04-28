using System.Linq;
using Faithlife.SurveyApi.v1.Client;

namespace Faithlife.SurveyApi.Core.Mappers
{
	internal static class SurveyMapper
	{
		public static Survey Map(SurveyDto dto)
		{
			return new Survey
			{
				Id = dto.Id,
				Title = dto.Title,
				Questions = dto.Questions.Select(q => new Question
				{
					QuestionId = q.Id,
					Prompt = q.Prompt
				}).ToList()
			};
		}

		public static SurveyDto MapToDto(Survey survey)
		{
			return new SurveyDto
			{
				Id = survey.Id,
				Title = survey.Title,
				Questions = survey.Questions.Select(q => new QuestionDto
				{
					Id = q.QuestionId,
					Prompt = q.Prompt
				}).ToList()
			};
		}
	}
}
