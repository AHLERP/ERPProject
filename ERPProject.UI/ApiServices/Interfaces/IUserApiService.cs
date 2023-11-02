using ERPProject.Entity.DTO.UserDTO;

namespace FirstProgramUI.ApiServices.Interfaces
{
    public interface IUserApiService
    {
        Task<List<UserDTOResponse>> GetListAsync();
        Task<UserDTOResponse> Update(long id);
    }
}
