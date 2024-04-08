using ECommerce.ENTITIES.Models;
using Newtonsoft.Json;
using RestSharp;

namespace ECommerce.Web.Service
{
    public class CategoryService
    {
        string url = "http://localhost:5251/Api/";
        public List<Category> GetAll()
        {           
            var client = new RestClient(url +"Category/all");
            var request = new RestRequest(url +"Category/all", Method.Get);
            RestResponse response = client.Execute(request);
            var categoryList = JsonConvert.DeserializeObject<List<Category>>(response.Content);
            return categoryList;
        }
    }
}
