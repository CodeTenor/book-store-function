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
    public class GetBookDetailsByIsbn
    {
        private readonly IOpenLibraryApiService _openLibraryApiService;

        public GetBookDetailsByIsbn(IOpenLibraryApiService openLibraryApiService)
        {
            _openLibraryApiService = openLibraryApiService;
        }

        [FunctionName("bookdetail")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string isbn = req.Query["isbn"];
            
            log.LogInformation($"GET: book/{isbn}");
            
            string response = _openLibraryApiService.GetBookDetailsByIsbn(isbn);

            return new OkObjectResult(JsonConvert.DeserializeObject(response));
        }
    }
}
