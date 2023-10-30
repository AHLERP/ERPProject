using AutoMapper;
using ERPProject.Business.Abstract;
using ERPProject.Entity.DTO.DepartmentDTO;
using ERPProject.Entity.Poco;
using ERPProject.Entity.Result;
using Microsoft.AspNetCore.Mvc;

namespace ERPProject.API.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;

        public DepartmentController(IMapper mapper, IDepartmentService departmentService)
        {
            _mapper = mapper;
            _departmentService = departmentService;
        }

        [HttpPost("/AddDepartment")]

        public async Task<IActionResult> AddDepartment(DepartmentDTORequest departmentDTORequest)
        {
            Department department = _mapper.Map<Department>(departmentDTORequest);
            await _departmentService.AddAsync(department);


            DepartmentDTOResponse departmentDTOResponse = _mapper.Map<DepartmentDTOResponse>(department);

            return Ok(Sonuc<DepartmentDTOResponse>.SuccessWithData(departmentDTOResponse));
        }


        [HttpPost("/RemoveDepartment/{departmentId}")]
        public async Task<IActionResult> RemoveDepartment(int departmentId)
        {
            Department department = await _departmentService.GetAsync(x=>x.Id == id);

            if (department == null)
            {
                return NotFound(Sonuc<DepartmentDTOResponse>.SuccessNoDataFound());
            }
            
            await _departmentService.RemoveAsync(department);

            return Ok(Sonuc<DepartmentDTOResponse>.SuccessWithoutData());
        }

        [HttpPost("/UpdateDepartment")]
        public async Task<IActionResult> UpdateDepartment(DepartmentDTORequest departmentDTORequest)
        {
            Department department = await _departmentService.GetAsync(x=>x.Id == departmentDTORequest.Id);
            if (department == null)
            {
                return NotFound(Sonuc<DepartmentDTOResponse>.SuccessNoDataFound());
            }
            _mapper.Map(departmentDTORequest,department);

            await _departmentService.UpdateAsync(department);


            DepartmentDTOResponse departmentDTOResponse = _mapper.Map<DepartmentDTOResponse>(department);
            return Ok(Sonuc<DepartmentDTOResponse>.SuccessWithData(departmentDTOResponse));
        }


        [HttpGet("/GetDepartment/{id}")]
        public async Task<IActionResult> GetDepartment(int id)
        {
            Department department = await _departmentService.GetAsync(x => x.Id == id,"Company");

            if (department == null)
            {
                return NotFound(Sonuc<DepartmentDTOResponse>.SuccessNoDataFound());
            }
            DepartmentDTOResponse departmentDTOResponse = _mapper.Map<DepartmentDTOResponse>(department);
            return Ok(Sonuc<DepartmentDTOResponse>.SuccessWithData(departmentDTOResponse));
        }

        [HttpGet("/GetDepartments")]
        public async Task<IActionResult> GetDepartments()
        {
            var departments = await _departmentService.GetAllAsync(x=>x.IsActive==true,"Company");
            if (departments == null)
            {
                return NotFound(Sonuc<DepartmentDTOResponse>.SuccessNoDataFound());
            }

            List<DepartmentDTOResponse> departmentDTOResponseList = new();
            foreach (var department in departments)
            {
                departmentDTOResponseList.Add(_mapper.Map<DepartmentDTOResponse>(department));
            }
            return Ok(Sonuc<List<DepartmentDTOResponse>>.SuccessWithData(departmentDTOResponseList));
        }


        [HttpGet("/GetDepartmentsByCompany/{id}")]
        public async Task<IActionResult> GetDepartments(int id)
        {
            var departments = await _departmentService.GetAllAsync(x => x.IsActive == true && x.CompanyId == id , "Company");

            if (departments == null)
            {
                return NotFound(Sonuc<DepartmentDTOResponse>.SuccessNoDataFound());
            }

            List<DepartmentDTOResponse> departmentDTOResponseList = new();
            foreach (var department in departments)
            {
                departmentDTOResponseList.Add(_mapper.Map<DepartmentDTOResponse>(department));
            }
            return Ok(Sonuc<List<DepartmentDTOResponse>>.SuccessWithData(departmentDTOResponseList));
        }
    }
}
