using ERPProject.Entity.Result;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ERPProject.UI.Areas
{
    public class BaseController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BaseController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;

        }
        protected async Task<bool> UpdateAsync<T>(T p, string url) where T : class
        {
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Header", "Bearer " + HttpContext.Session.GetString("Token"));
            var jsonData = JsonConvert.SerializeObject(p);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync(url, stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
        protected async Task<bool> AddAsync<T>(T p, string url) where T : class
        {
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Header", "Bearer " + HttpContext.Session.GetString("Token"));
            var jsonData = JsonConvert.SerializeObject(p);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync(url, stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
        protected async Task<bool> DeleteAsync(string url)
        {
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Header", "Bearer " + HttpContext.Session.GetString("Token"));
            var responserMessage = await client.DeleteAsync(url);

            if (responserMessage.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
        protected async Task<Sonuc<List<T>>> GetAllAsync<T>(string url) where T : class
        {
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Header", "Bearer " + HttpContext.Session.GetString("Token"));
            var responserMessage = await client.GetAsync(url);
            if (responserMessage.IsSuccessStatusCode)
            {
                var jsonData = await responserMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<Sonuc<List<T>>>(jsonData);

                return value;
            }
            return null;
        }
        protected async Task<Sonuc<List<T>>> GetAsync<T>(string url) where T : class
        {
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Header", "Bearer " + HttpContext.Session.GetString("Token"));
            var responserMessage = await client.GetAsync(url);
            if (responserMessage.IsSuccessStatusCode)
            {
                var jsonData = await responserMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<Sonuc<List<T>>>(jsonData);

                return value;
            }
            return null;
        }

    }

}
