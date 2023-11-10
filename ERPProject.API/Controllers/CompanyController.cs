using AutoMapper;
using ERPProject.Business.Abstract;
using ERPProject.Business.ValidationRules.FluentValidation;
using ERPProject.Core.Aspects;
using ERPProject.Entity.DTO.CompanyDTO;
using ERPProject.Entity.Poco;
using ERPProject.Entity.Result;
using FluentValidation.Internal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;


namespace ERPProject.API.Controllers
{
    [ApiController]
    [Route("[action]")]


    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;
        private readonly IDepartmentService _departmentService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public CompanyController(IMapper mapper, ICompanyService companyService, IDepartmentService departmentService, IUserService userService)
        {
            _mapper = mapper;
            _companyService = companyService;
            _departmentService = departmentService;
            _userService = userService;
        }

        [HttpPost("/AddCompany")]
        [ValidationFilter(typeof(CompanyValidator))]
        public async Task<ActionResult> AddCompany(CompanyDTORequest companyDTORequest)
        {
            Company company = _mapper.Map<Company>(companyDTORequest);
            await _companyService.AddAsync(company);


            CompanyDTOResponse companyDTOResponse = _mapper.Map<CompanyDTOResponse>(company);

            Log.Information("Companies => {@companyDTOResponse} => { Şirket Eklendi. }", companyDTOResponse);

            return Ok(Sonuc<CompanyDTOResponse>.SuccessWithData(companyDTOResponse));
        }


        [HttpDelete("/RemoveCompany/{id}")]
        public async Task<IActionResult> RemoveCompany(int id)
        {
            Company company = await _companyService.GetAsync(x => x.Id == id);

            if (company == null)
            {
                return NotFound(Sonuc<CompanyDTOResponse>.SuccessNoDataFound());
            }

            await _companyService.RemoveAsync(company);

            Log.Information("Companies => {@company} => { Şirket Silindi. }", company);

            return Ok(Sonuc<CompanyDTOResponse>.SuccessWithoutData());
        }

        [HttpPost("/UpdateCompany")]
        [ValidationFilter(typeof(CompanyValidator))]
        public async Task<IActionResult> UpdateCompany(CompanyDTORequest companyDTORequest)
        {
            Company company = await _companyService.GetAsync(x => x.Id == companyDTORequest.Id);
            if (company == null)
            {
                return NotFound(Sonuc<CompanyDTOResponse>.SuccessNoDataFound());
            }

            company = _mapper.Map(companyDTORequest, company);

            await _companyService.UpdateAsync(company);

            CompanyDTOResponse companyDTOResponse = _mapper.Map<CompanyDTOResponse>(company);

            Log.Information("Companies => {@companyDTOResponse} => { Şirket Güncellendi. }", companyDTOResponse);

            return Ok(Sonuc<CompanyDTOResponse>.SuccessWithData(companyDTOResponse));
        }


        [HttpGet("/GetCompany/{id}")]
        public async Task<IActionResult> GetCompany(int id)
        {
            Company company = await _companyService.GetAsync(x => x.Id == id);
            if (company == null)
            {
                return NotFound(Sonuc<CompanyDTOResponse>.SuccessNoDataFound());
            }

            CompanyDTOResponse companyDTOResponse = _mapper.Map<CompanyDTOResponse>(company);

            Log.Information("Companies => {@companyDTOResponse} => { Şirket Getirildi. }", companyDTOResponse);

            return Ok(Sonuc<CompanyDTOResponse>.SuccessWithData(companyDTOResponse));
        }

        
        [HttpGet("/GetCompanies")]
        public async Task<IActionResult> GetCompanies()
        {
            var companies = await _companyService.GetAllAsync(x => x.IsActive == true);
            if (companies == null)
            {
                return Ok(Sonuc<CompanyDTOResponse>.SuccessWithoutData());
            }
            List<CompanyDTOResponse> companyDTOResponseList = new();
            foreach (var company in companies)
            {
                companyDTOResponseList.Add(_mapper.Map<CompanyDTOResponse>(company));
            }

            Log.Information("Companies => {@companyDTOResponse} => { Şirketler Getirildi. } ", companyDTOResponseList);

            return Ok(Sonuc<List<CompanyDTOResponse>>.SuccessWithData(companyDTOResponseList));
        }

        [HttpGet("/GetCompaniesByUser/{userId}")]
        public async Task<IActionResult> GetCompaniesByUser(long userId)
        {
            User user = await _userService.GetAsync(x => x.Id == userId);
            Department department = await _departmentService.GetAsync(x => x.Id == user.DepartmentId);
            Company company = await _companyService.GetAsync(x => x.Id == department.CompanyId);

            var companies = await _companyService.GetAllAsync(x => x.IsActive == true && x.Id == company.Id);

            if (companies == null)
            {
                return Ok(Sonuc<CompanyDTOResponse>.SuccessWithoutData());
            }
            List<CompanyDTOResponse> companyDTOResponseList = new();
            foreach (var item in companies)
            {
                companyDTOResponseList.Add(_mapper.Map<CompanyDTOResponse>(item));
            }

            Log.Information("Companies => {@companyDTOResponse} => { Şirketler Getirildi. } ", companyDTOResponseList);

            return Ok(Sonuc<List<CompanyDTOResponse>>.SuccessWithData(companyDTOResponseList));
        }
    }
}
