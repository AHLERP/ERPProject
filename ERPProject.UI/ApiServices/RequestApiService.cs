using ERPProject.Entity.Poco;
using FirstProgramUI.ApiServices.Interfaces;

namespace FirstProgramUI.ApiServices
{
    public class RequestApiService : IRequestApiService
    {
        private HttpClient _httpClient;
        public RequestApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Request>> GetListAsync()
        {
            var response = await _httpClient.GetAsync("Requests/GetRequests");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var responseSuccess = await response.Content.ReadFromJsonAsync<IEnumerable<Request>>();
            return responseSuccess.ToList();
        }
    }
}
