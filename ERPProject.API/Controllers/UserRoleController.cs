using AutoMapper;
using ERPProject.Business.Abstract;
using ERPProject.Entity.DTO.UserRoleDTO;
using ERPProject.Entity.Poco;
using ERPProject.Entity.Result;
using Microsoft.AspNetCore.Mvc;

namespace ERPProject.API.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class UserRoleController : Controller
    {
        private readonly IUserRoleService _userRoleService;
        private readonly IMapper _mapper;

        public UserRoleController(IMapper mapper, IUserRoleService userRoleService)
        {
            _mapper = mapper;
            _userRoleService = userRoleService;
        }

        [HttpPost("/AddUserRole")]
        public async Task<IActionResult> AddUserRole(UserRoleDTORequest userRoleDTORequest)
        {
            UserRole userRole = _mapper.Map<UserRole>(userRoleDTORequest);
            await _userRoleService.AddAsync(userRole);

            UserRoleDTOResponse userRoleDTOResponse = _mapper.Map<UserRoleDTOResponse>(userRole);
            return Ok(Sonuc<UserRoleDTOResponse>.SuccessWithData(userRoleDTOResponse));
        }

        [HttpGet("/UserRoles")]
        public async Task<IActionResult> GetUserRoles()
        {
            var userRoles = await _userRoleService.GetAllAsync(x=>x.IsActive==true,"User","Role");
            if (userRoles == null)
            {
                return NotFound(Sonuc<UserRoleDTOResponse>.SuccessNoDataFound());
            }

            List<UserRoleDTOResponse> userRoleDTOResponseList = new();
            foreach (var userRole in userRoles)
            {
                userRoleDTOResponseList.Add(_mapper.Map<UserRoleDTOResponse>(userRole));
            }

            return Ok(Sonuc<List<UserRoleDTOResponse>>.SuccessWithData(userRoleDTOResponseList));
        }

        [HttpGet("/UserRolesByUser/{userId}")]
        public async Task<IActionResult> GetUserRolesByUser(long userId)
        {
            var userRoles = await _userRoleService.GetAllAsync(x => x.IsActive == true && x.UserId==userId, "User", "Role");
            if (userRoles == null)
            {
                return NotFound(Sonuc<UserRoleDTOResponse>.SuccessNoDataFound());
            }

            List<UserRoleDTOResponse> userRoleDTOResponseList = new();
            foreach (var userRole in userRoles)
            {
                userRoleDTOResponseList.Add(_mapper.Map<UserRoleDTOResponse>(userRole));
            }

            return Ok(Sonuc<List<UserRoleDTOResponse>>.SuccessWithData(userRoleDTOResponseList));
        }

        [HttpGet("/UserRolesByRole/{roleId}")]
        public async Task<IActionResult> GetUserRolesByRole(long roleId)
        {
            var userRoles = await _userRoleService.GetAllAsync(x => x.IsActive == true && x.RoleId == roleId, "User", "Role");
            if (userRoles == null)
            {
                return NotFound(Sonuc<UserRoleDTOResponse>.SuccessNoDataFound());
            }

            List<UserRoleDTOResponse> userRoleDTOResponseList = new();
            foreach (var userRole in userRoles)
            {
                userRoleDTOResponseList.Add(_mapper.Map<UserRoleDTOResponse>(userRole));
            }

            return Ok(Sonuc<List<UserRoleDTOResponse>>.SuccessWithData(userRoleDTOResponseList));
        }
    }
}
