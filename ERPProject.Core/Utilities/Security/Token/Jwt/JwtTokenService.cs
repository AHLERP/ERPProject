using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ERPProject.Core.Utilities.Security.Token.Jwt
{
    public class JwtTokenService : ITokenService
    {
        private readonly AppSettings _appSettings;
        public JwtTokenService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public AccessToken CreateToken(long userId, string userName, int roleId) //
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecurityKey);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier,userId.ToString()),
                    new Claim(ClaimTypes.Name,userName),
                    new Claim(ClaimTypes.Role,roleId.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new AccessToken()
            {
                Token = tokenHandler.WriteToken(token),
                Expiration = (DateTime)tokenDescriptor.Expires,
                UserName = userName,
                UserId = userId,
                RoleId= roleId
            };
        }
    }
}
