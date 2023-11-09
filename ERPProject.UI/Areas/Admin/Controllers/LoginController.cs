using ERPProject.Entity.DTO.UserLoginDTO;
using ERPProject.Entity.Result;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace ERPProject.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        //private readonly string url = "https://localhost:7075/";
        private readonly HttpClient _httpClient;

        public LoginController(HttpClient httpclient)
        {
            _httpClient = httpclient;
        }

        [HttpPost("/Admin/GirisYap")]
        public async Task<IActionResult> Index(LoginDTO p)
        {
            var url = "https://localhost:7075/Login";
            var client = new RestClient(url);
            var request = new RestRequest(url, RestSharp.Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = JsonConvert.SerializeObject(p);
            request.AddBody(body, "application/json");
            RestResponse response = await client.ExecuteAsync(request);
            var responseObject = JsonConvert.DeserializeObject<ApiResponse<LoginDTO>>(response.Content);
            if(responseObject.StatusCode==200) { 
            HttpContext.Session.SetString("Token", responseObject.Data.Token);
            HttpContext.Session.SetString("Role", responseObject.Data.RoleName);
            HttpContext.Session.SetString("Company", responseObject.Data.CompanyId.ToString());
            HttpContext.Session.SetString("Department", responseObject.Data.DepartmentId.ToString());
            HttpContext.Session.SetString("DepartmentName", responseObject.Data.DepartmentName);
            HttpContext.Session.SetString("User", responseObject.Data.UserId.ToString());



            }
            else
            {
                TempData["HATA"] = "Hatalı Giriş Yaptınız";
                return RedirectToAction("","");
            }
            HttpContext.Session.SetString("User", responseObject.Data.UserId.ToString());


            if (response.IsSuccessStatusCode&& HttpContext.Session.GetString("Role")=="Admin")
            {
                return RedirectToAction("Index","Company");
            }
            else if (response.IsSuccessStatusCode && HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToAction("Sirketler", "Kullanici");
            }


            return RedirectToAction("Index", "Home");
        }
    }
}
