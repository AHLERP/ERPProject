using ERPProject.Entity.Result;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace ERPProject.UI.Areas
{
    public class BaseController : Controller
    {
        private readonly HttpClient _httpClient;


        public BaseController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:7075/api/");



        }

        protected async Task<bool> UpdateAsync<T>(T p, string url) where T : class
        {
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + HttpContext.Session.GetString("token"));


            var jsonData = JsonConvert.SerializeObject(p);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
<<<<<<< Updated upstream
            var responseMessage = await client.PutAsync(url, stringContent);
=======
            var responseMessage = await _httpClient.PostAsync(url, stringContent);

>>>>>>> Stashed changes

            if (responseMessage.IsSuccessStatusCode)
            {
                _httpClient.DefaultRequestHeaders.Remove("Authorization");
                return true;
            }

            return false;
        }
        protected async Task<bool> AddAsync<T>(T p, string url) where T : class
        {
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + HttpContext.Session.GetString("token"));
            var jsonData = JsonConvert.SerializeObject(p);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await _httpClient.PostAsync(url, stringContent);


            if (responseMessage.IsSuccessStatusCode)
            {
                _httpClient.DefaultRequestHeaders.Remove("Authorization");
                return true;
            }

            return false;
        }
        protected async Task<bool> DeleteAsync(string url)
        {
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + HttpContext.Session.GetString("token"));
            
            HttpResponseMessage responseMessage = await _httpClient.DeleteAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                _httpClient.DefaultRequestHeaders.Remove("Authorization");
                return true;
            }

            return false;
        }
        protected async Task<List<T>> GetAllAsync<T>(string url) where T : class
        {
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + HttpContext.Session.GetString("token"));

            HttpResponseMessage responseMessage = await _httpClient.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ApiResponse<List<T>>>(jsonData);
                if (value != null)
                {
                    _httpClient.DefaultRequestHeaders.Remove("Authorization");
                    return value.Data;
                }
<<<<<<< Updated upstream

 
            }
            return null;
        }
        protected async Task<T> GetAsync<T>(string url) where T : class
        {
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + HttpContext.Session.GetString("token"));       
            var responseMessage = await _httpClient.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ApiResponse<T>>(jsonData);
                _httpClient.DefaultRequestHeaders.Remove("Authorization");
                return value.Data;
            }
            return null;
        }

    }

}

