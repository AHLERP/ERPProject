using ERPProject.Entity.DTO.CompanyDTO;
using ERPProject.Entity.DTO.DepartmentDTO;
using ERPProject.Entity.DTO.RequestDTO;
using ERPProject.Entity.DTO.RoleDTO;
using ERPProject.Entity.DTO.UserDTO;
using ERPProject.UI.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERPProject.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : BaseController
    {
        private readonly string url = "https://localhost:7075/";
        public UserController(HttpClient httpClient) : base(httpClient)
        {

        }
        [HttpGet("/Admin/Kullanicilar")]
        public async Task<IActionResult> Index()
        {
            var dep = HttpContext.Session.GetString("DepartmentName");
            string rol = HttpContext.Session.GetString("Role");
            if (rol != "Personel" || dep == "Insan Kaynaklari")
            {
                var id = HttpContext.Session.GetString("User");
                var val = await GetAllAsync<UserDTOResponse>(url + "GetUsersByDepartment/" + id);

                if (dep == "Admin")
                {
                    val = await GetAllAsync<UserDTOResponse>(url + "GetUsers");
                }
                if (rol == "Departman Müdürü")
                {
                    val = await GetAllAsync<UserDTOResponse>(url + "GetUsersByDepartment/" + id);
                }
                if (rol == "Şirket Müdürü" || dep == "Insan Kaynaklari")
                {
                    val = await GetAllAsync<UserDTOResponse>(url + "GetUsersByCompany/" + id);
                }
                if (val.StatusCode == 401)
                {
                    return RedirectToAction("Unauthorized", "Home");
                }
                if (val.StatusCode == 403)
                {
                    return RedirectToAction("Forbidden", "Home");
                }
                var val2 = await GetAllAsync<DepartmentDTOResponse>(url + "GetDepartments");
                var val3 = await GetAllAsync<RoleDTOResponse>(url + "Roles");
                var val4 = await GetAllAsync<CompanyDTOResponse>(url + "GetCompanies");
                //var val4 = await GetAllAsync<RequestDTOResponse>(url + "GetRequests");


                UserVM userVM = new UserVM
                {
                    Departments = val2.Data,
                    Users = val.Data,
                    Roles = val3.Data,
                    Requests = null,
                    Companies = val4.Data

                };

                return View(userVM);
            }
            return RedirectToAction("Forbidden", "Home");
        }
        [HttpGet("/Admin/Kullanici")]
        public async Task<IActionResult> Profile()
        {
            var userId = Convert.ToInt64(HttpContext.Session.GetString("User"));  
            var val = await GetAsync<UserDTOResponse>(url + "GetUser/" + userId);
            if (val.StatusCode == 401)
            {
                return RedirectToAction("Unauthorized", "Home");
            }
            else if (val.StatusCode == 403)
            {
                return RedirectToAction("Forbidden", "Home");
            }
            return View(val.Data);
        }
        [HttpPost("/Admin/KullaniciEkle")]
        public async Task<IActionResult> Add(UserDTORequest p, IFormFile imageFile)
        {
            var dep = HttpContext.Session.GetString("DepartmentName");
            if (dep == "Insan Kaynaklari" || dep == "Yonetim" || dep == "Admin")
            {

                if (imageFile != null && imageFile.Length > 0)
                {
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
                    var imagePath = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "UserImage", uniqueFileName);

                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }
                    p.Image = "UserImage/" + uniqueFileName;
                    p.AddedUser = Convert.ToInt64(HttpContext.Session.GetString("User"));
                    p.UpdatedUser = Convert.ToInt64(HttpContext.Session.GetString("User"));
                    var val = await AddAsync(p, url + "AddUser");
                    if (val.StatusCode == 401)
                    {
                        return RedirectToAction("Unauthorized", "Home");
                    }
                    else if (val.StatusCode == 403)
                    {
                        return RedirectToAction("Forbidden", "Home");
                    }
                    if (val == null)
                    {
                        return RedirectToAction("Forbidden", "Home");
                    }
                    if (val.Data != null)
                    {
                        return RedirectToAction("Index", "User");

                    }
                }
            }
            return RedirectToAction("Forbidden", "Home");

        }
        [HttpPost("/Admin/KullaniciGuncelle")]
        public async Task<IActionResult> Update(UserDTORequest p, IFormFile imageFile)
        {
            var dep = HttpContext.Session.GetString("DepartmentName");
            if (dep == "Insan Kaynaklari" || dep == "Yonetim" || dep == "Admin")
            {

                if (imageFile != null && imageFile.Length > 0)

                {
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
                    var imagePath = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "UserImage", uniqueFileName);

                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }
                    p.Image = "UserImage/" + uniqueFileName;
                    p.UpdatedUser = Convert.ToInt64(HttpContext.Session.GetString("User"));
                    var val = await UpdateAsync(p, url + "UpdateUser");
                    if (val.StatusCode == 401)
                    {
                        return RedirectToAction("Unauthorized", "Home");
                    }
                    else if (val.StatusCode == 403)
                    {
                        return RedirectToAction("Forbidden", "Home");
                    }
                    if (val == null)
                    {
                        return RedirectToAction("Forbidden", "Home");
                    }
                    if (val.Data != null)
                    {
                        return RedirectToAction("Kullanicilar", "Admin");

                    }
                }
            }
            return RedirectToAction("Forbidden", "Home");

        }
        [HttpGet("/Admin/KullaniciSil/{id}")]
        public async Task<IActionResult> Delete(Int64 id)
        {
            var val = await DeleteAsync(url + "RemoveUser/" + id);
            var dep = HttpContext.Session.GetString("DepartmentName");
            if (!(dep != "Insan Kaynaklari" || dep != "Yonetim" || dep != "Admin"))
            {
                return RedirectToAction("Forbidden", "Home");
            }
            if (val)
            {
                return RedirectToAction("Kullanicilar", "Admin");

            }
            return RedirectToAction("Forbidden", "Home");

        }
    }
}
