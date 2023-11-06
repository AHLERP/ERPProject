
using ERPProject.Entity.DTO.UserLoginDTO;
using ERPProject.Entity.Poco;
using ERPProject.Entity.Result;

namespace FirstProgramUI.ApiServices.Interfaces
{
    public interface IAuthApiService
    {
        Task<Sonuc<User>> LoginAsync(LoginDTO loginDto);
    }
}
