using ERPProject.Entity.DTO.UserDTO;
using ERPProject.Entity.DTO.UserLoginDTO;
using ERPProject.Entity.Result;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace ERPProject.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {
        private readonly HttpClient _httpClient;
        public AuthController(HttpClient httpClient)
        {
            _httpClient = httpClient;

        }

        [HttpGet("/Admin/GirisYap")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("/Admin/GirisYap2")]
        public async Task<IActionResult> Index(LoginDTO loginDto)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("https://localhost:7075/api/Auth/Login\r\n", loginDto);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var data = await httpResponseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ApiResponse<UserDTOResponse>>(data);
                HttpContext.Session.SetString("token", result.Data.Token);
                var userClaims = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                userClaims.AddClaim(new Claim(ClaimTypes.NameIdentifier, result.Data.Id.ToString()));
                userClaims.AddClaim(new Claim(ClaimTypes.Name, result.Data.Email));
                userClaims.AddClaim(new Claim(ClaimTypes.Role, result.Data.RoleId.ToString()));
                var claimPrincipal = new ClaimsPrincipal(userClaims);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal);
                return RedirectToAction("Index", "Company");

            }

            else
            {
                return View();
            }
        }
    }
}