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
	/// <summary>
	/// Response for CreateSurvey.
	/// </summary>
	[System.CodeDom.Compiler.GeneratedCode("fsdgencsharp", "")]
	public sealed partial class CreateSurveyResponseDto : ServiceDto<CreateSurveyResponseDto>
	{
		/// <summary>
		/// Creates an instance.
		/// </summary>
		public CreateSurveyResponseDto()
		{
		}

		public SurveyDto Survey { get; set; }

		/// <summary>
		/// Determines if two DTOs are equivalent.
		/// </summary>
		public override bool IsEquivalentTo(CreateSurveyResponseDto other)
		{
			return other != null &&
				ServiceDataUtility.AreEquivalentDtos(Survey, other.Survey);
		}
	}
}