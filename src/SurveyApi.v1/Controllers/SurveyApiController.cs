using Faithlife.SurveyApi.v1.Client.Http;
using Microsoft.AspNetCore.Mvc;

namespace SurveyApi.v1.Controllers
{
	public sealed partial class SurveyApiController : ControllerBase
	{
		public SurveyApiController(SurveyApiHttpHandler httpHandler)
		{
			m_httpHandler = httpHandler;
		}

		private SurveyApiHttpHandler GetServiceHttpHandler() => m_httpHandler;

		private readonly SurveyApiHttpHandler m_httpHandler;
	}
}
