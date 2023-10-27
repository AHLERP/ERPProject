using AutoMapper;
using ERPProject.Business.Abstract;
using ERPProject.Entity.DTO.UserDTO;
using ERPProject.Entity.Poco;
using ERPProject.Entity.Result;
using Microsoft.AspNetCore.Mvc;

namespace ERPProject.API.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost("/AddUser")]
        public async Task<IActionResult> AddUser(UserDTORequest userDTORequest)
        {
            User user = _mapper.Map<User>(userDTORequest);
            await _userService.AddAsync(user);

            UserDTOResponse userDTOResponse = _mapper.Map<UserDTOResponse>(user);
            return Ok(Sonuc<UserDTOResponse>.SuccessWithData(userDTOResponse));
        }

        [HttpPost("/RemoveUser/{userId}")]
        public async Task<IActionResult> RemoveUser(long id)
        {
            User user = await _userService.GetAsync(x=>x.Id == id);
            if (user == null)
            {
                return NotFound(Sonuc<UserDTOResponse>.SuccessNoDataFound());
            }
            await _userService.RemoveAsync(user);
            return Ok(Sonuc<UserDTOResponse>.SuccessWithoutData());
        }

        [HttpPost("/UpdateUser")]
        public async Task<IActionResult> UpdateUser(UserDTORequest userDTORequest)
        {
            User user = await _userService.GetAsync(x=>x.Id == userDTORequest.Id);
            if (user == null)
            {
                return NotFound(Sonuc<UserDTOResponse>.SuccessNoDataFound());
            }
            user = _mapper.Map(userDTORequest,user);
            await _userService.UpdateAsync(user);

            UserDTOResponse userDTOResponse = _mapper.Map<UserDTOResponse>(user);
            return Ok(Sonuc<UserDTOResponse>.SuccessWithData(userDTOResponse)) ;
        }

        [HttpGet("/GetUser/{userId}")]
        public async Task<IActionResult> GetUser(long userId)
        {
            User user = await _userService.GetAsync(x=>x.Id == userId);
            if (user == null)
            {
                return NotFound(Sonuc<UserDTOResponse>.SuccessNoDataFound());
            }

            UserDTOResponse userDTOResponse = _mapper.Map<UserDTOResponse>(user);
            return Ok(Sonuc<UserDTOResponse>.SuccessWithData(userDTOResponse));
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetAllAsync(x=>x.IsActive==true,"Department","Role");
            if (users == null)
            {
                return NotFound(Sonuc<UserDTOResponse>.SuccessNoDataFound());
            }
            List<UserDTOResponse> userDTOResponseList = new();
            foreach (var user in users)
            {
                userDTOResponseList.Add(_mapper.Map<UserDTOResponse>(user));
            }
            return Ok(Sonuc<List<UserDTOResponse>>.SuccessWithData(userDTOResponseList));
        }

        [HttpGet("GetUsersByDepartment/{departmentId}")]
        public async Task<IActionResult> GetUsersByDepartment(int departmentId)
        {
            var users = await _userService.GetAllAsync(x => x.IsActive == true && x.DepartmentId==departmentId, "Department", "Role");
            if (users == null)
            {
                return NotFound(Sonuc<UserDTOResponse>.SuccessNoDataFound());
            }
            List<UserDTOResponse> userDTOResponseList = new();
            foreach (var user in users)
            {
                userDTOResponseList.Add(_mapper.Map<UserDTOResponse>(user));
            }
            return Ok(Sonuc<List<UserDTOResponse>>.SuccessWithData(userDTOResponseList));
        }

        [HttpGet("GetUsersByRole/{roleId}")]
        public async Task<IActionResult> GetUsersByRole(int roleId)
        {
            var users = await _userService.GetAllAsync(x => x.IsActive == true && x.DepartmentId == roleId, "Department", "Role");
            if (users == null)
            {
                return NotFound(Sonuc<UserDTOResponse>.SuccessNoDataFound());
            }
            List<UserDTOResponse> userDTOResponseList = new();
            foreach (var user in users)
            {
                userDTOResponseList.Add(_mapper.Map<UserDTOResponse>(user));
            }
            return Ok(Sonuc<List<UserDTOResponse>>.SuccessWithData(userDTOResponseList));
        }
    }
}
