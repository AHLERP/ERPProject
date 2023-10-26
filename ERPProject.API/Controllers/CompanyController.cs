using AutoMapper;
using ERPProject.Business.Abstract;
using ERPProject.Entity.DTO.CompanyDTO;
using ERPProject.Entity.Poco;
using ERPProject.Entity.Result;
using Microsoft.AspNetCore.Mvc;

namespace ERPProject.API.Controllers
{
    [ApiController]
    [Route("[action]")]
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
        public ActionResult AddCompany(CompanyDTORequest companyDTORequest)
        {
            Company company = _mapper.Map<Company>(companyDTORequest);
            _companyService.Add(company);

            CompanyDTOResponse companyDTOResponse = _mapper.Map<CompanyDTOResponse>(company);
            return Ok(Sonuc<CompanyDTOResponse>.SuccessWithData(companyDTOResponse));
        }

        [HttpPost("/RemoveCompany/{id}")]
        public async Task<IActionResult> RemoveCompany(int id)
        {
            Company company = await _companyService.GetAsync(x=>x.Id == id);
            if (company == null)
            {
                return NotFound(Sonuc<CompanyDTOResponse>.SuccessNoDataFound());
            }

            _companyService.Remove(company);
            return Ok(Sonuc<CompanyDTOResponse>.SuccessWithoutData());
        }

        [HttpPost("/UpdateCompany")]
        public async Task<IActionResult> UpdateCompany(CompanyDTORequest companyDTORequest)
        {
            Company company = await _companyService.GetAsync(x=>x.Id == companyDTORequest.Id);
            if (company==null)
            {
                return NotFound(Sonuc<CompanyDTOResponse>.SuccessNoDataFound());
            }

            company = _mapper.Map(companyDTORequest, company);
            _companyService.Update(company);

            CompanyDTOResponse companyDTOResponse = _mapper.Map<CompanyDTOResponse>(company);
            return Ok(Sonuc<CompanyDTOResponse>.SuccessWithData(companyDTOResponse));
        }

        [HttpGet("/GetCompany/{id}")]
        public async Task<IActionResult> GetCompany(int id)
        {
            Company company = await _companyService.GetAsync(x=>x.Id == id);
            if (company==null)
            {
                return NotFound(Sonuc<CompanyDTOResponse>.SuccessNoDataFound());
            }

            CompanyDTOResponse companyDTOResponse = _mapper.Map<CompanyDTOResponse>(company);
            return Ok(Sonuc<CompanyDTOResponse>.SuccessWithData(companyDTOResponse));
        }

        [HttpGet("/GetCompanies")]
        public async Task<IActionResult> GetCompanies()
        {
            var companies = await _companyService.GetAllAsync(x=>x.IsActive == true);
            if (companies == null)
            {
                return NotFound(Sonuc<CompanyDTOResponse>.SuccessNoDataFound());
            }
            List<CompanyDTOResponse> companyDTOResponseList = new();
            foreach (var company in companies)
            {
                companyDTOResponseList.Add(_mapper.Map<CompanyDTOResponse>(company));
            }
            return Ok(Sonuc<List<CompanyDTOResponse>>.SuccessWithData(companyDTOResponseList));
        }
    }
}
