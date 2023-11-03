using AutoMapper;
using ERPProject.Business.Abstract;
using ERPProject.Entity.DTO.LoginDTO;
using ERPProject.Entity.DTO.UserDTO;
using ERPProject.Entity.Poco;
using ERPProject.Entity.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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


            var user = await _userService.GetAsync(x => x.Email == loginRequestDTO.KullaniciAdi,"Role");
            if (user == null)
            {
                return NotFound("Kullanıcı bulunamadı");
            }

            //var verifyPasswords = BCrypt.Net.BCrypt.Verify(loginRequestDTO.Sifre, user.Password);

            UserDTOResponse response = _mapper.Map<UserDTOResponse>(user);


            if (BCrypt.Net.BCrypt.Verify(loginRequestDTO.Sifre, user.Password))
            {
                List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name , response.Name),
                new Claim(ClaimTypes.Surname , response.LastName),
                new Claim(ClaimTypes.Email , response.Email),
                new Claim(ClaimTypes.Role,response.RoleId.ToString()),
                new Claim("Email",response.Email)
            };



                var key = Encoding.UTF8.GetBytes(_configuration.GetValue<string>("AppSettings:Token"));

                //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value!));

                //var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);



                var token = new JwtSecurityToken
                    (
                    claims: claims,
                    expires: DateTime.Now.AddDays(30),
                    notBefore: DateTime.Now,
                    //signingCredentials: creds,
                    signingCredentials:new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)

                   
                    );

                var jwt = new JwtSecurityTokenHandler().WriteToken(token);

                LoginResponseDTO loginResponseDTO = new()
                {
                    AdSoyad = user.Name + user.LastName,
                    EPosta = user.Email,
                    Token = jwt,
                    RoleName = user.RoleId.ToString()
                    
                };

                return Ok(Sonuc<LoginResponseDTO>.SuccessWithData(loginResponseDTO));
            }


            return BadRequest("Şifre Yanlış.");

        }

    }
}
