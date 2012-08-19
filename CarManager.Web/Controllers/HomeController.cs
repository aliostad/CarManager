using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace CarManager.Web.Controllers
{
	public class HomeController : ApiController
	{
		public HttpResponseMessage Get()
		{
			var httpResponseMessage = new HttpResponseMessage( HttpStatusCode.OK);
			var manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("CarManager.Web.readme.txt");
			var memoryStream = new MemoryStream();
			manifestResourceStream.CopyTo(memoryStream);
			httpResponseMessage.Content = new ByteArrayContent(memoryStream.ToArray());
			httpResponseMessage.Content.Headers.ContentType =
				new MediaTypeHeaderValue("text/plain");
			return httpResponseMessage;
		}
	}
}