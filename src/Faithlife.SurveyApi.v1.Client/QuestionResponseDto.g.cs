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
	public sealed partial class QuestionResponseDto : ServiceDto<QuestionResponseDto>
	{
		/// <summary>
		/// Creates an instance.
		/// </summary>
		public QuestionResponseDto()
		{
		}

		public string QuestionId { get; set; }

		public string Response { get; set; }

		/// <summary>
		/// Determines if two DTOs are equivalent.
		/// </summary>
		public override bool IsEquivalentTo(QuestionResponseDto other)
		{
			return other != null &&
				QuestionId == other.QuestionId &&
				Response == other.Response;
		}
	}
}