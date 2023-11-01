using ERPProject.Core.Utilities.Response;
using ERPProject.Entity.DTO.UserLoginDTO;
using ERPProject.Entity.Poco;
using FirstProgramUI.ApiServices.Interfaces;
using Newtonsoft.Json;

namespace FirstProgramUI.ApiServices
{
    public class AuthApiService : IAuthApiService
    {
        private readonly HttpClient _httpClient;

        public AuthApiService(HttpClient httpClient)
        {
            _httpClient=httpClient;
        }
        public async Task<ApiDataResponse<User>> LoginAsync(LoginDTO loginDto)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("Auths/Login", loginDto);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var data = await httpResponseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ApiDataResponse<User>>(data);
                return await Task.FromResult(result);
            }
            return null;
        }
    }
}
