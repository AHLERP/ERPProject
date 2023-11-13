using AutoMapper;
using ERPProject.Business.Abstract;
using ERPProject.Business.ValidationRules.FluentValidation;
using ERPProject.Core.Aspects;
using ERPProject.Entity.DTO.StockDetailDTO;
using ERPProject.Entity.DTO.UserDTO;
using ERPProject.Entity.Poco;
using ERPProject.Entity.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace ERPProject.API.Controllers
{
    [ApiController]
    [Route("[action]")]
    [Authorize(Roles = "Admin,Şirket Müdürü,Departman Müdürü")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IDepartmentService _departmentService;
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public UserController(IMapper mapper, IUserService userService, ICompanyService companyService, IDepartmentService departmentService)
        {
            _mapper = mapper;
            _userService = userService;
            _companyService = companyService;
            _departmentService = departmentService;
        }

        [HttpPost("/AddUser")]
        [ValidationFilter(typeof(UserValidator))]
        public async Task<IActionResult> AddUser(UserDTORequest userDTORequest)
        {
            User user = _mapper.Map<User>(userDTORequest);

            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            await _userService.AddAsync(user);

            UserDTOResponse userDTOResponse = _mapper.Map<UserDTOResponse>(user); 

            Log.Information("Users => {@userDTOResponse} => { Kullanıcı Eklendi. }", userDTOResponse);

            return Ok(Sonuc<UserDTOResponse>.SuccessWithData(userDTOResponse));
        }

        [HttpDelete("/RemoveUser/{userId}")]

        public async Task<IActionResult> RemoveUser(Int64 userId)
        {
            User user = await _userService.GetAsync(x=>x.Id == userId);
            if (user == null)
            {
                return NotFound(Sonuc<UserDTOResponse>.SuccessNoDataFound());
            }
            await _userService.RemoveAsync(user);

            Log.Information("Users => {@user} => { Kullanıcı Silindi. }", user);

            return Ok(Sonuc<UserDTOResponse>.SuccessWithoutData());
        }

        [HttpPost("/UpdateUser")]
        [ValidationFilter(typeof(UserValidator))]
        public async Task<IActionResult> UpdateUser(UserDTORequest userDTORequest)
        {
            User user = await _userService.GetAsync(x=>x.Id == userDTORequest.Id);
            if (user == null)
            {
                return NotFound(Sonuc<UserDTOResponse>.SuccessNoDataFound());
            }
            user = _mapper.Map(userDTORequest,user);
            //user.Password = BCrypt.Net.BCrypt.HashPassword(userDTORequest.Password);
            await _userService.UpdateAsync(user);

            UserDTOResponse userDTOResponse = _mapper.Map<UserDTOResponse>(user);

            Log.Information("Users => {@userDTOResponse} => { Kullanıcı Güncellendi. }", userDTOResponse);

            return Ok(Sonuc<UserDTOResponse>.SuccessWithData(userDTOResponse)) ;
        }

        [HttpGet("/GetUser/{userId}")]
        public async Task<IActionResult> GetUser(long userId)
        {
            User user = await _userService.GetAsync(x=>x.Id == userId,"Role","Department");
            if (user == null)
            {
                return NotFound(Sonuc<UserDTOResponse>.SuccessNoDataFound());
            }

            UserDTOResponse userDTOResponse = _mapper.Map<UserDTOResponse>(user);

            Log.Information("Users => {@userDTOResponse} => { Kullanıcı Getirildi. }", userDTOResponse);

            return Ok(Sonuc<UserDTOResponse>.SuccessWithData(userDTOResponse));
        }

        [HttpGet("/GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            
            var users = await _userService.GetAllAsync(x=>x.IsActive==true,"Department.Company","Role");
            
            if (users == null)
            {
                return NotFound(Sonuc<UserDTOResponse>.SuccessNoDataFound());
            }
            List<UserDTOResponse> userDTOResponseList = new();
            foreach (var item in users)
            {
                userDTOResponseList.Add(_mapper.Map<UserDTOResponse>(item));
                
            }


            Log.Information("Users => {@userDTOResponse} => { Kullanıcılar Getirildi. }", userDTOResponseList);

            return Ok(Sonuc<List<UserDTOResponse>>.SuccessWithData(userDTOResponseList));
        }

        [HttpGet("/GetUsersByDepartment/{userId}")]
        public async Task<IActionResult> GetUsersByDepartment(int userId)
        {
            User user = await _userService.GetAsync(x=>x.Id == userId);
            Department department = await _departmentService.GetAsync(x=>x.Id == user.DepartmentId);

            var users = await _userService.GetAllAsync(x => x.IsActive == true && x.DepartmentId==department.Id, "Department.Company", "Role");
            if (users == null)
            {
                return NotFound(Sonuc<UserDTOResponse>.SuccessNoDataFound());
            }
            List<UserDTOResponse> userDTOResponseList = new();
            foreach (var item in users)
            {
                userDTOResponseList.Add(_mapper.Map<UserDTOResponse>(item));
            }

            Log.Information("Users => {@userDTOResponse} => { Departmana Göre Kullanıcılar Getirildi. }", userDTOResponseList);

            return Ok(Sonuc<List<UserDTOResponse>>.SuccessWithData(userDTOResponseList));
        }

        



        [HttpGet("/GetUsersByRole/{roleId}")]
        public async Task<IActionResult> GetUsersByRole(int roleId)
        {
            var users = await _userService.GetAllAsync(x => x.IsActive == true && x.DepartmentId == roleId, "Department.Company", "Role");
            if (users == null)
            {
                return NotFound(Sonuc<UserDTOResponse>.SuccessNoDataFound());
            }
            List<UserDTOResponse> userDTOResponseList = new();
            foreach (var user in users)
            {
                userDTOResponseList.Add(_mapper.Map<UserDTOResponse>(user));
            }

            Log.Information("Users => {@userDTOResponse} => { Rollere Göre Kullanıcılar Getirildi. }", userDTOResponseList);

            return Ok(Sonuc<List<UserDTOResponse>>.SuccessWithData(userDTOResponseList));
        }

        [HttpGet("/GetUsersByCompany/{userId}")]
        public async Task<IActionResult> GetUsersByCompany(int userId)
        {
            User user = await _userService.GetAsync(x=>x.Id == userId);
            Department department = await _departmentService.GetAsync(x=>x.Id == user.DepartmentId);
            Company company = await _companyService.GetAsync(x=>x.Id == department.CompanyId);
            

            var users = await _userService.GetAllAsync(x => x.IsActive == true && x.Department.CompanyId == company.Id, "Department.Company", "Role");
            if (users == null)
            {
                return NotFound(Sonuc<UserDTOResponse>.SuccessNoDataFound());
            }
            List<UserDTOResponse> userDTOResponseList = new();
            foreach (var item in users)
            {
                
                userDTOResponseList.Add(_mapper.Map<UserDTOResponse>(item));
                
            }

            foreach (var item in userDTOResponseList)
            {
                item.CompanyName = company.Name;
            }

            Log.Information("Users => {@userDTOResponse} => { Şirkete Göre Kullanıcılar Getirildi. }", userDTOResponseList);

            return Ok(Sonuc<List<UserDTOResponse>>.SuccessWithData(userDTOResponseList));
        }


    }


}
