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
	/// Request for SubmitSurveyResponse.
	/// </summary>
	[System.CodeDom.Compiler.GeneratedCode("fsdgencsharp", "")]
	public sealed partial class SubmitSurveyResponseRequestDto : ServiceDto<SubmitSurveyResponseRequestDto>
	{
		/// <summary>
		/// Creates an instance.
		/// </summary>
		public SubmitSurveyResponseRequestDto()
		{
		}

		public SurveyResponseDto Response { get; set; }

		/// <summary>
		/// Determines if two DTOs are equivalent.
		/// </summary>
		public override bool IsEquivalentTo(SubmitSurveyResponseRequestDto other)
		{
			return other != null &&
				ServiceDataUtility.AreEquivalentDtos(Response, other.Response);
		}
	}
}
