using AutoMapper;
using Azure.Core;
using ERPProject.Business.Abstract;
using ERPProject.Business.ValidationRules.FluentValidation;
using ERPProject.Core.Aspects;
using ERPProject.Entity.DTO.RequestDTO;
using ERPProject.Entity.DTO.RoleDTO;
using ERPProject.Entity.Poco;
using ERPProject.Entity.Result;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace ERPProject.API.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class RoleController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }


        [HttpGet("/Roles")]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _roleService.GetAllAsync();

            if (roles == null)
            {
                return NotFound(Sonuc<List<RoleDTOResponse>>.SuccessNoDataFound());
            }
            List<RoleDTOResponse> roleDTOResponses = new();

            foreach (var item in roles)
            {
                roleDTOResponses.Add(_mapper.Map<RoleDTOResponse>(item));
            }

            Log.Information("Roles => {@roleDTOResponse}", roleDTOResponses);
            return Ok(Sonuc<List<RoleDTOResponse>>.SuccessWithData(roleDTOResponses));

        }

        [HttpGet("/Role/{roleId}")]
        public async Task<IActionResult> GetRole(int roleId)
        {
            var role =  await _roleService.GetAsync(e => e.Id == roleId);
            if(role == null)
            {
                return NotFound(Sonuc<RoleDTOResponse>.SuccessNoDataFound());
            }
            RoleDTOResponse roleDTOResponse = _mapper.Map<RoleDTOResponse>(role);

            Log.Information("Roles => {@roleDTOResponse}", roleDTOResponse);

            return Ok(Sonuc<RoleDTOResponse>.SuccessWithData(roleDTOResponse));

        }

        [HttpPost("/AddRole")]
        [ValidationFilter(typeof(RoleValidator))]
        public async Task<IActionResult> AddRole(RoleDTORequest roleDTORequest)
        {

            var role = _mapper.Map<Role>(roleDTORequest);
            await _roleService.AddAsync(role);
            RoleDTOResponse roleDTOResponse = _mapper.Map<RoleDTOResponse>(role);

            Log.Information("Roles => {@roleDTOResponse}", roleDTOResponse);

            return Ok(Sonuc<RoleDTOResponse>.SuccessWithData(roleDTOResponse));

        }

        [HttpPost("/UpdateRole")]
        [ValidationFilter(typeof(RoleValidator))]
        public async Task<IActionResult> UpdateRole(RoleDTORequest roleDTORequest)
        {
            Role role = await _roleService.GetAsync(e => e.Id == roleDTORequest.Id);

            if (role == null)
            {
                return NotFound(Sonuc<RoleDTOResponse>.SuccessNoDataFound());
            }

            _mapper.Map(roleDTORequest,role);
            await _roleService.UpdateAsync(role);

            RoleDTOResponse roleDTOResponse = _mapper.Map<RoleDTOResponse>(role);

            Log.Information("Roles => {@roleDTOResponse}", roleDTOResponse);

            return Ok(Sonuc<RoleDTOResponse>.SuccessWithData(roleDTOResponse));
        }

        [HttpDelete("/RemoveRole/{roleId}")]
        public async Task<IActionResult> RemoveRole(int roleId)
        {
            Role role = await _roleService.GetAsync(e => e.Id == roleId);
            if (role == null)
            {
                return NotFound(Sonuc<RoleDTOResponse>.SuccessNoDataFound());
            }
            await _roleService.RemoveAsync(role);

            Log.Information("Roles => {@role}", role);

            return Ok(Sonuc<RoleDTOResponse>.SuccessWithoutData());

        }



    }
}
