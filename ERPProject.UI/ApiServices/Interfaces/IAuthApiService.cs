using ERPProject.Core.Utilities.Response;
using ERPProject.Entity.DTO.UserLoginDTO;
using ERPProject.Entity.Poco;

namespace FirstProgramUI.ApiServices.Interfaces
{
    public interface IAuthApiService
    {
        Task<ApiDataResponse<User>> LoginAsync(LoginDTO loginDto);
    }
}
