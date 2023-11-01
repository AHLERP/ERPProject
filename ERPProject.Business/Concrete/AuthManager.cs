using AutoMapper;
using ERPProject.Business.Abstract;
using ERPProject.Business.Abstract.DataManagement;
using ERPProject.Core.Utilities.Response;
using ERPProject.Core.Utilities.Security.Token;
using ERPProject.DataAccess.Abstract;
using ERPProject.Entity.DTO.UserDTO;
using ERPProject.Entity.DTO.UserLoginDTO;
using ERPProject.Entity.Poco;
using ERPProject.Entity.Result;

namespace ERPProject.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserRepository _repo;
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly IGenericService<User> _genericService;
        public AuthManager(IUserService userService, ITokenService tokenService, IMapper mapper, IUserRepository repo, IGenericService<User> genericService)
        {
            _tokenService = tokenService;
            _userService = userService;
            _mapper = mapper;
            _repo = repo;
            _genericService = genericService;
        }
        public async Task<ApiDataResponse<User>> LoginAsync(LoginDTO loginDto)
        {
            var user = await _repo.GetAsync(x => x.Email == loginDto.UserName && x.Password == loginDto.UserPassword);
            if (user == null)
            {
                return new ErrorApiDataResponse<User>(null, "kullanıcı bulunamadı");
            }
            else
            {
                if (user.TokenExpireDate == null || string.IsNullOrEmpty(user.Token))
                {
                    var accessToken = _tokenService.CreateToken(user.Id, user.Name,user.RolId);
                    UserDTORequest userUpdateDto = _mapper.Map<UserDTORequest>(user);
                    userUpdateDto.Token = accessToken.Token;
                    userUpdateDto.TokenExpireDate = accessToken.Expiration;
                    var resultNewUserUpdateDto = _mapper.Map<User>(userUpdateDto);
                    await _userService.UpdateAsync(resultNewUserUpdateDto);
                    //var resultNewUserUpdateDto = await _userService.UpdateAsync(userUpdateDto);
                    var userDto = _mapper.Map<User>(resultNewUserUpdateDto);
                    return new SuccessApiDataResponse<User>(userDto, "giriş başarılı");

                }
                if (user.TokenExpireDate < DateTime.Now)
                {
                    var accessToken = _tokenService.CreateToken(user.Id, user.Name,user.RolId);
                    UserDTORequest userUpdateDto = _mapper.Map<UserDTORequest>(user);
                    userUpdateDto.Token = accessToken.Token;
                    userUpdateDto.TokenExpireDate = accessToken.Expiration;
                    var resultNewUserUpdateDto = _mapper.Map<User>(userUpdateDto);
                    await _userService.UpdateAsync(resultNewUserUpdateDto);
                    //var resultNewUserUpdateDto = await _userService.UpdateAsync(userUpdateDto);
                    var userDto = _mapper.Map<User>(resultNewUserUpdateDto);
                    return new SuccessApiDataResponse<User>(userDto, "giriş başarılı");
                }
            }
            return new SuccessApiDataResponse<User>(user, "giriş başarılı");
        }
    }
}
