using ECommerce.ENTITIES.Models;
using Newtonsoft.Json;
using RestSharp;

namespace ECommerce.Web.Service
{
    public class ProductService
    {
        string url = "http://localhost:5251/Api/";
        public List<Product> GetAllCategoryProduct(int categoryId)
        {
            var client = new RestClient(url + $"Product/category/{categoryId}");
            var request = new RestRequest(url + $"Product/category/{categoryId}", Method.Get);
            RestResponse response = client.Execute(request);
            var productList = JsonConvert.DeserializeObject<List<Product>>(response.Content);
            return productList;
        }
    }
}
