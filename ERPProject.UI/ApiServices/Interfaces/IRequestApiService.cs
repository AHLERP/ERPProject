using ERPProject.Entity.Poco;

namespace FirstProgramUI.ApiServices.Interfaces
{
    public interface IRequestApiService
    {
        Task<List<Request>> GetListAsync();
    }
}
