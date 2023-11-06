using AutoMapper;
using ERPProject.Business.Abstract;
using ERPProject.Entity.DTO.LoginDTO;
using ERPProject.Entity.DTO.StockDetailDTO;
using ERPProject.Entity.DTO.UserDTO;
using ERPProject.Entity.Poco;
using ERPProject.Entity.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ERPProject.API.Controllers
{
    [ApiController]
    [Route("[action]")]
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public LoginController(IConfiguration configuration, IUserService userService, IMapper mapper)
        {
            _configuration = configuration;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("/Login")]
        public async Task<IActionResult> LoginAsync(LoginRequestDTO loginRequestDTO)
          {


            var user = await _userService.GetAsync(x => x.Email == loginRequestDTO.KullaniciAdi, "Role");
            if (user == null)
            {
                return NotFound("Kullanıcı bulunamadı");
            }


            if (BCrypt.Net.BCrypt.Verify(loginRequestDTO.Sifre, user.Password))
            {
                List<Claim> claims = new List<Claim>()
                {
                new Claim(ClaimTypes.Name , user.Name),
                new Claim(ClaimTypes.Surname , user.LastName),
                new Claim(ClaimTypes.Email , user.Email),
                new Claim(ClaimTypes.Role,user.Role.Name.ToString()),
                new Claim("EmailForMW",user.Email)
                };

                var secretKey = _configuration["JWT:Token"];
                var issuer = _configuration["JWT:Issuer"];
                var audiance = _configuration["JWT:Audiance"];


                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(secretKey);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Audience = audiance,
                    Issuer = issuer,
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddDays(20), // Token süresi (örn: 20 dakika)
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);

                LoginResponseDTO loginResponseDTO = new()
                {
                    AdSoyad = user.Name + user.LastName,
                    EPosta = user.Email,
                    Token = tokenHandler.WriteToken(token),
                    RoleName = user.Role.Name.ToString()
                };

                Log.Information("LoginResponse => {@loginResponseDTO}", loginResponseDTO);
                return Ok(Sonuc<LoginResponseDTO>.SuccessWithData(loginResponseDTO));
            }


            return BadRequest("Şifre Yanlış.");

        }

    }
}
