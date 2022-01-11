using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using Domain.Identity;
using Domain.Entities;
using System.Net.Http.Headers;

namespace FoodDelivery.Persistence
{
    public class ApiDataProvider : IDataProvider
    {
        private HttpClient httpClient { get; set; }

        public ApiDataProvider()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization 
                = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoidmVnYUFkbWluIiwianRpIjoiNDExNWY0NDMtMDk3NC00Zjc4LThhZjktODc0NTU1NGM0ZmM0IiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiQWRtaW4iLCJleHAiOjE2MzcyNDUzNzgsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NjE5NTUiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjQyMDAifQ.UmW98JPHilH2XIwclFcfk8Fma7rONKesUZROzPfFs3I");
        }

        public IEnumerable<FoodItem> GetAll()
        {
            string url = @"https://localhost:44384/api/index";
            string json = httpClient.GetStringAsync(url).Result;
            return JsonConvert.DeserializeObject<IEnumerable<FoodItem>>(json);
        }

        public FoodItem GetItemById(int id)
        {
            string url = @$"https://localhost:44384/api/index/{id}";
            string json = httpClient.GetStringAsync(url).Result;
            return JsonConvert.DeserializeObject<FoodItem>(json);
        }

        public void AddItem(FoodItemDto2 item)
        {
            var c = new MultipartFormDataContent();

            c.Add(new StringContent(item.Name.ToString(), Encoding.UTF8, "text/plain"), "dto.Name");
            c.Add(new StringContent(item.Price.ToString(), Encoding.UTF8, "text/plain"), "dto.Price");
            c.Add(new StreamContent(item.Image.OpenReadStream()), "image", item.Image.FileName);
            c.Add(new StringContent(item.Description.ToString(), Encoding.UTF8, "text/plain"), "dto.Description");
            string url = @"https://localhost:44384/api/index";
            var response = httpClient.PostAsync(
                requestUri: url,
                content: c).Result;
        }

        public void EditItem(FoodItemDto2 item)
        {
            var c = new MultipartFormDataContent();

            c.Add(new StringContent(item.Id.ToString(), Encoding.UTF8, "text/plain"), "dto.Id");
            c.Add(new StringContent(item.Name.ToString(), Encoding.UTF8, "text/plain"), "dto.Name");
            c.Add(new StringContent(item.Price.ToString(), Encoding.UTF8, "text/plain"), "dto.Price");
            c.Add(new StreamContent(item.Image.OpenReadStream()), "image", item.Image.FileName);
            c.Add(new StringContent(item.Description.ToString(), Encoding.UTF8, "text/plain"), "dto.Description");

            string url = @"https://localhost:44384/api/index";
            var response = httpClient.PutAsync(
                requestUri: url,
                content: c).Result;
        }

        public void DeleteItem(int id)
        {
            string url = @$"https://localhost:44384/api/index/{id}";
            var response = httpClient.DeleteAsync(url);
        }
    }
}
