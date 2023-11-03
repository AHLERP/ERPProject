using AutoMapper;
using ERPProject.Business.Abstract;
using ERPProject.Core.Utilities.Security.Token;
using ERPProject.DataAccess.Abstract.DataManagement;
using ERPProject.Entity.DTO.UserDTO;
using ERPProject.Entity.DTO.UserLoginDTO;
using ERPProject.Entity.Result;

namespace ERPProject.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUnitOfWork _uow;
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        public AuthManager(IUserService userService, ITokenService tokenService, IMapper mapper, IUnitOfWork repo)
        {
            _tokenService = tokenService;
            _userService = userService;
            _mapper = mapper;
            _uow = repo;
        }

        public async Task<Sonuc<UserDTOResponse>> LoginAsync(LoginDTO loginDto)
        {
            var user = await _uow.UserRepository.GetAsync(x => x.Email == loginDto.UserName && x.Password == loginDto.UserPassword, "Department", "Role");
            if (user == null)
            {
                return Sonuc<UserDTOResponse>.SuccessNoDataFound();
            }
            else
            {
                if (user.TokenExpireDate == null || string.IsNullOrEmpty(user.Token))
                {
                    var accessToken = _tokenService.CreateToken(user.Id, user.Name, user.RoleId);
                    var userUpdateDto = _mapper.Map<UserDTOResponse>(user);
                    userUpdateDto.Token = accessToken.Token;
                    userUpdateDto.TokenExpireDate = accessToken.Expiration;
                    var resultNewUserUpdateDto = await _userService.UpdateAsyncForLogin(userUpdateDto);
                    var userDto = _mapper.Map<UserDTOResponse>(resultNewUserUpdateDto);
                    return Sonuc<UserDTOResponse>.SuccessWithData(userDto);
                }
                if (user.TokenExpireDate < DateTime.Now)
                {
                    var accessToken = _tokenService.CreateToken(user.Id, user.Name, user.RoleId);
                    var userUpdateDto = _mapper.Map<UserDTOResponse>(user);
                    userUpdateDto.Token = accessToken.Token;
                    userUpdateDto.TokenExpireDate = accessToken.Expiration;
                    var resultNewUserUpdateDto = await _userService.UpdateAsyncForLogin(userUpdateDto);
                    var userDto = _mapper.Map<UserDTOResponse>(resultNewUserUpdateDto);
                    return Sonuc<UserDTOResponse>.SuccessWithData(userDto);
                }
            }
            UserDTOResponse userDTOResponse = _mapper.Map<UserDTOResponse>(user);
            return Sonuc<UserDTOResponse>.SuccessWithData(userDTOResponse);
        }
    }
}