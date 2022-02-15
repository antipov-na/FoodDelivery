using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using Domain.Entities;
using System.Net.Http.Headers;
using UseCases.Core.DTOs;

namespace FoodDelivery.Persistence
{
    public class ApiDataProvider : IDataProvider
    {
        private HttpClient httpClient { get; set; }

        public ApiDataProvider()
        {
            httpClient = new HttpClient();
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

        public void AddItem(CreateFoodItemDto item)
        {
            var c = new MultipartFormDataContent();

            c.Add(new StringContent(item.Name.ToString(), Encoding.UTF8, "text/plain"), "dto.Name");
            c.Add(new StringContent(item.Price.ToString(), Encoding.UTF8, "text/plain"), "dto.Price");
            //c.Add(new StreamContent(item.Image.OpenReadStream()), "image", item.Image.FileName);
            c.Add(new StringContent(item.Description.ToString(), Encoding.UTF8, "text/plain"), "dto.Description");
            string url = @"https://localhost:44384/api/index";
            var response = httpClient.PostAsync(
                requestUri: url,
                content: c).Result;
        }

        public void EditItem(CreateFoodItemDto item)
        {
            var c = new MultipartFormDataContent();

            c.Add(new StringContent(item.Id.ToString(), Encoding.UTF8, "text/plain"), "dto.Id");
            c.Add(new StringContent(item.Name.ToString(), Encoding.UTF8, "text/plain"), "dto.Name");
            c.Add(new StringContent(item.Price.ToString(), Encoding.UTF8, "text/plain"), "dto.Price");
            //c.Add(new StreamContent(item.Image.OpenReadStream()), "image", item.Image.FileName);
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
