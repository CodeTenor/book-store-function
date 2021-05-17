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
    public class Search
    {
        private readonly IOpenLibraryApiService _openLibraryApiService;

        public Search(IOpenLibraryApiService openLibraryApiService)
        {
            _openLibraryApiService = openLibraryApiService;
        }

        [FunctionName("Search")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string query = req.Query["q"];

            log.LogInformation($"GET: book/{query}");

            string response = _openLibraryApiService.SearchBooks(query);

            return new OkObjectResult(JsonConvert.DeserializeObject(response));
        }
    }
}
