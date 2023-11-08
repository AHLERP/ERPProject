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

    //[Authorize(Roles="Admin")]


    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(IMapper mapper, ICompanyService companyService)
        {
            _mapper = mapper;
            _companyService = companyService;
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
    }
}
