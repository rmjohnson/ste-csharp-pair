// <auto-generated>
// DO NOT EDIT: generated by fsdgencsharp
// </auto-generated>
using System;
using System.Collections.Generic;
using Facility.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Faithlife.SurveyApi.v1.Client
{
	[System.CodeDom.Compiler.GeneratedCode("fsdgencsharp", "")]
	public sealed partial class SurveyDto : ServiceDto<SurveyDto>
	{
		/// <summary>
		/// Creates an instance.
		/// </summary>
		public SurveyDto()
		{
		}

		public string Id { get; set; }

		public string Title { get; set; }

		public IReadOnlyList<QuestionDto> Questions { get; set; }

		/// <summary>
		/// Determines if two DTOs are equivalent.
		/// </summary>
		public override bool IsEquivalentTo(SurveyDto other)
		{
			return other != null &&
				Id == other.Id &&
				Title == other.Title &&
				ServiceDataUtility.AreEquivalentFieldValues(Questions, other.Questions);
		}
	}
}