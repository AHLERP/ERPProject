using ERPProject.Entity.DTO.DepartmentDTO;
using ERPProject.Entity.DTO.RequestDTO;
using ERPProject.Entity.DTO.RoleDTO;
using ERPProject.Entity.DTO.UserDTO;
using ERPProject.UI.Areas.Admin.Models;
using FirstProgramUI.ApiServices.Interfaces;

namespace FirstProgramUI.ApiServices
{
    public class UserApiService : IUserApiService
    {
        private HttpClient _httpClient;
        public UserApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserDTOResponse> Update(long id)
        {
            var response = await _httpClient.GetFromJsonAsync<List<UserDTOResponse>>("User/GetById/" + id);
            var val1 = await _httpClient.GetFromJsonAsync<List<RequestDTOResponse>>("Request/GetRequests");
            var val2 = await _httpClient.GetFromJsonAsync<List<DepartmentDTOResponse>>("Department/GetDepartments");
            var val3 = await _httpClient.GetFromJsonAsync<List<RoleDTOResponse>>("Role/GetRoles");

            UserVM updateViewModels = new UserVM()
            {
                Departments = val2,
                Roles = val3,
                Requests = val1,
                Users = response,
            };
            if (updateViewModels == null)
            {
                return null;
            }
            return null;
        }

        public async Task<List<UserDTOResponse>> GetListAsync()
        {
            var response = await _httpClient.GetAsync("User/GetUsers");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var responseSuccess = await response.Content.ReadFromJsonAsync<IEnumerable<UserDTOResponse>>();
            return responseSuccess.ToList();
        }
    }
}
