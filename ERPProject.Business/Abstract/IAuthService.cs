using ERPProject.Business.Abstract.DataManagement;
using ERPProject.Core.Utilities.Response;
using ERPProject.Entity.DTO.UserDTO;
using ERPProject.Entity.DTO.UserLoginDTO;
using ERPProject.Entity.Poco;
using ERPProject.Entity.Result;

namespace ERPProject.Business.Abstract
{
    public interface IAuthService
    {
        Task<ApiDataResponse<User>> LoginAsync(LoginDTO loginDto);
    }
}
