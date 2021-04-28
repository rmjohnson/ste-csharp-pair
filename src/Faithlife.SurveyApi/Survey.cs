using System;
using System.Collections.Generic;
using System.Linq;

namespace Faithlife.SurveyApi
{
	public sealed class Survey
	{
		public string Id { get; set; }
		public string Title { get; set; }
		public IReadOnlyList<Question> Questions { get; set; }

		public Survey Clone()
		{
			return new Survey
			{
				Id = Id,
				Questions = Questions.Select(qr => qr.Clone()).ToList(),
			};
		}
	}
}
