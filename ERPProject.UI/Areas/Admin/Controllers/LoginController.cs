using ERPProject.Core.Utilities.Response;
using ERPProject.Entity.DTO.LoginDTO;
using ERPProject.Entity.DTO.OfferDTO;
using ERPProject.Entity.DTO.UserDTO;
using ERPProject.Entity.DTO.UserLoginDTO;
using ERPProject.Entity.Poco;
using ERPProject.Entity.Result;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;

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
            HttpContext.Session.SetString("Token", responseObject.Data.Token);

            
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Company");
            }
            

            return RedirectToAction("Index", "Home");
        }
    }
}
