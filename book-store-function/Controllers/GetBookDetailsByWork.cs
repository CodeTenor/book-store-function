using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using book_store_function.Services;

namespace book_store_function
{
    public class GetBookDetailsByWork
    {
        private readonly IOpenLibraryApiService _openLibraryApiService;

        public GetBookDetailsByWork(IOpenLibraryApiService openLibraryApiService)
        {
            _openLibraryApiService = openLibraryApiService;
        }

        [FunctionName("bookwork")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string work = req.Query["work"];
            
            log.LogInformation($"GET: {work}");

            string response = _openLibraryApiService.GetBookDetailsByWork(work);

            return new OkObjectResult(JsonConvert.DeserializeObject(response));
        }
    }
}
