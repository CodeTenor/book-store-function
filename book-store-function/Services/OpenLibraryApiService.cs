using RestSharp;
using System;

namespace book_store_function.Services
{
    public class OpenLibraryApiService: IOpenLibraryApiService
    {
        public string SearchBooks(string query)
        {
            try
            {
                var client = new RestClient($"http://openlibrary.org/search.json?q={query.Replace(' ', '+')}");

                client.Timeout = -1;

                RestRequest request = new RestRequest(Method.GET);

                IRestResponse response = client.Execute(request);

                return response.Content;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GetBookDetailsByIsbn(string isbn)
        {
            try
            {
                var client = new RestClient($"http://openlibrary.org/api/books?bibkeys=ISBN:{isbn}&format=json&jscmd=details");

                client.Timeout = -1;

                RestRequest request = new RestRequest(Method.GET);

                IRestResponse response = client.Execute(request);

                return response.Content;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GetBookDetailsByWork(string work)
        {
            try
            {
                var client = new RestClient($"http://openlibrary.org${work}.json");

                client.Timeout = -1;

                RestRequest request = new RestRequest(Method.GET);

                IRestResponse response = client.Execute(request);

                return response.Content;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
