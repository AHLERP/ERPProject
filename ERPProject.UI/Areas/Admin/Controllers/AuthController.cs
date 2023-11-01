using ERPProject.Entity.DTO.UserLoginDTO;
using FirstProgramUI.ApiServices.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FirstProgramUI.Controllers
{
    public class AuthController : Controller
    {
        private IAuthApiService _authApiService;
        private HttpClient _httpClient;
        public AuthController(IAuthApiService authApiService, HttpClient httpClient)
        {
            _authApiService = authApiService;
            _httpClient = httpClient;
        }
        [HttpGet]
        public IActionResult Login()
        {
            HttpContext.Session.Clear();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDto)
        {
            var user = await _authApiService.LoginAsync(loginDto);
            if (user != null && user.Success)
            {

                HttpContext.Session.SetString("token", user.Data.Token);
                var userClaims = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                userClaims.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Data.Id.ToString()));
                userClaims.AddClaim(new Claim(ClaimTypes.Name, user.Data.Email));
                userClaims.AddClaim(new Claim(ClaimTypes.Role, user.Data.RolId.ToString()));
                var claimPrincipal = new ClaimsPrincipal(userClaims);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Hatalı!");
            }
            return View(loginDto);
        }
    }
}
