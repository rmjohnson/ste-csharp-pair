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
	/// Response for SubmitSurveyResponse.
	/// </summary>
	[System.CodeDom.Compiler.GeneratedCode("fsdgencsharp", "")]
	public sealed partial class SubmitSurveyResponseResponseDto : ServiceDto<SubmitSurveyResponseResponseDto>
	{
		/// <summary>
		/// Creates an instance.
		/// </summary>
		public SubmitSurveyResponseResponseDto()
		{
		}

		public SurveyResponseDto Response { get; set; }

		/// <summary>
		/// Determines if two DTOs are equivalent.
		/// </summary>
		public override bool IsEquivalentTo(SubmitSurveyResponseResponseDto other)
		{
			return other != null &&
				ServiceDataUtility.AreEquivalentDtos(Response, other.Response);
		}
	}
}