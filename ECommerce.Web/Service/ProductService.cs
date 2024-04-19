using ECommerce.ENTITIES.Models;
using Newtonsoft.Json; 
using RestSharp;

// This code uses a library called RestSharp to make HTTP requests. It also converts JSON data to C# objects using the Newtonsoft.Json library.

namespace ECommerce.Web.Service
{
    public class ProductService
    {
        private readonly string baseUrl;

        public ProductService(string baseUrl)
        {
            this.baseUrl = baseUrl.TrimEnd('/') + "/Api/Product/category/";
        }
        public List<Product> GetAllCategoryProduct(int categoryId)
        {
            var client = new RestClient(baseUrl + $"{categoryId}"); // It is a library used to make HTTP requests. 
            var request = new RestRequest(baseUrl + $"{categoryId}", Method.Get); // HTTP GET request 

            try
            {
                var response = client.Execute(request);

                if (response.IsSuccessful)
                {
                    return JsonConvert.DeserializeObject<List<Product>>(response.Content);
                }
                else
                {
                    // Handle unsuccessful response, such as logging the error
                    Console.WriteLine("Request failed with status code: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, such as logging the error
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            return new List<Product>(); // Return an empty list in case of errors
        }
    }
}
