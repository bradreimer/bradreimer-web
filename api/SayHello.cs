using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Schrody
{
    public static class SayHello
    {
		private static int s_fletch;
		private static int s_fibs;
		private static int s_brad;

        [FunctionName("SayHello")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

			int count = name switch
			{
				"Fletch" => ++s_fletch,
				"Fibs" => ++s_fibs,
				"Brad" => ++s_brad,
				_ => 0
			};

			string responseMessage =
				$"<strong>Hello human!</strong> {count} people have said hello to me";

            return new OkObjectResult(responseMessage);
        }
    }
}
