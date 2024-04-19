using ECommerce.ENTITIES.Models;
using Newtonsoft.Json;
using RestSharp;

namespace ECommerce.Web.Service
{
    public class CategoryService 
    {    
        private readonly string baseUrl;

        public CategoryService(string baseUrl)
        {
            this.baseUrl = baseUrl.TrimEnd('/') + "/Api/Category";
        }

        public List<Category> GetAll()
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest("all", Method.Get);

            try
            {
                var response = client.Execute(request);

                if (response.IsSuccessful)
                {
                    return JsonConvert.DeserializeObject<List<Category>>(response.Content);
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

            return new List<Category>(); // Return an empty list in case of errors
        }

    }
}
