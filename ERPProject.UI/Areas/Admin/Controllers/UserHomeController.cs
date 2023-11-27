using ERPProject.Entity.DTO.UserDTO;
using Microsoft.AspNetCore.Mvc;

namespace ERPProject.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserHomeController : BaseController
    {
        private readonly string url = "https://localhost:7075/";
        public UserHomeController(HttpClient httpClient) : base(httpClient)
        {
        }

        [HttpGet("/Admin/Anasayfa")]
        public async Task<IActionResult> Index()
        {
            var userId = Convert.ToInt64(HttpContext.Session.GetString("User"));
            var val = await GetAsync<UserDTOResponse>(url+ "GetUser/"+userId);

            UserDTOResponse userDTO = new()
            {
                Id=val.Data.Id,
                CompanyId=val.Data.CompanyId,
                CompanyName=val.Data.CompanyName,
                DepartmentId=val.Data.DepartmentId,
                DepartmentName=val.Data.DepartmentName,
                Name=val.Data.Name,
                LastName=val.Data.LastName,
                RoleName=val.Data.RoleName.ToList(),
                Email=val.Data.Email,
                Phone=val.Data.Phone,
            };


            return View(userDTO);
        }
    }
}
