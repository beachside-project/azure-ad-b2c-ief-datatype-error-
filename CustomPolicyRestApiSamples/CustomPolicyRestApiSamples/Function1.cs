using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;

namespace CustomPolicyRestApiSamples
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            var content = new ApiResponseContent() { Id = Guid.NewGuid().ToString(), Timestamp = DateTime.Now };
            log.LogInformation($"Response: {JsonConvert.SerializeObject(content)}");
            return new OkObjectResult(content);
        }
    }

    public class ApiResponseContent
    {
        public string Id { get; set; }

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }
    }
}