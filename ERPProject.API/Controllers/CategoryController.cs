using AutoMapper;
using ERPProject.Business.Abstract;
using ERPProject.Business.ValidationRules.FluentValidation;
using ERPProject.Core.Aspects;
using ERPProject.Entity.DTO.BrandDTO;
using ERPProject.Entity.DTO.CategoryDTO;
using ERPProject.Entity.Poco;
using ERPProject.Entity.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace ERPProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]


    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(IMapper mapper, ICategoryService categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }
        [Authorize(Roles = "Admin,Satın Alma Personeli,Satın Alma Departman Müdürü,Şirket Müdürü,Yönetim Kurulu Başkanı")]
        [HttpPost("/AddCategory")]
        [ValidationFilter(typeof(CategoryValidator))]
        public async Task<IActionResult> AddCategory(CategoryDTORequest categoryDTORequest)
        {
            Category category = _mapper.Map<Category>(categoryDTORequest);
            await _categoryService.AddAsync(category);

            CategoryDTOResponse categoryDTOResponse = _mapper.Map<CategoryDTOResponse>(category);

            Log.Information("Categories => {@categoryDTOResponse} => { Kategori Eklendi. }", categoryDTOResponse);

            return Ok(Sonuc<CategoryDTOResponse>.SuccessWithData(categoryDTOResponse));
        }

        [Authorize(Roles = "Admin,Satın Alma Personeli,Satın Alma Departman Müdürü,Şirket Müdürü,Yönetim Kurulu Başkanı")]
        [HttpDelete("/RemoveCategory/{categoryId}")]
        public async Task<IActionResult> RemoveCategory(int categoryId)
        {
            Category category = await _categoryService.GetAsync(x => x.Id == categoryId);
            if (category == null)
            {
                return NotFound(Sonuc<CategoryDTOResponse>.SuccessNoDataFound());
            }

            await _categoryService.RemoveAsync(category);

            Log.Information("Categories => {@category} => { Kategori Silindi. }", category);

            return Ok(Sonuc<CategoryDTOResponse>.SuccessWithoutData());
        }

        [Authorize(Roles = "Admin,Satın Alma Personeli,Satın Alma Departman Müdürü,Şirket Müdürü,Yönetim Kurulu Başkanı")]
        [HttpPost("/UpdateCategory")]
        [ValidationFilter(typeof(CategoryValidator))]
        public async Task<IActionResult> UpdateCategory(CategoryDTORequest categoryDTORequest)
        {
            Category category = await _categoryService.GetAsync(x => x.Id == categoryDTORequest.Id);
            if (category == null)
            {
                return NotFound(Sonuc<CategoryDTOResponse>.SuccessNoDataFound());
            }
            category = _mapper.Map(categoryDTORequest, category);
            await _categoryService.UpdateAsync(category);

            CategoryDTOResponse categoryDTOResponse = _mapper.Map<CategoryDTOResponse>(category);

            Log.Information("Categories => {@categoryDTOResponse} => { Kategori Güncellendi. }", categoryDTOResponse);

            return Ok(Sonuc<CategoryDTOResponse>.SuccessWithData(categoryDTOResponse));
        }

        [Authorize(Roles = "Admin,Satın Alma Personeli,Satın Alma Departman Müdürü,Şirket Müdürü,Yönetim Kurulu Başkanı")]
        [HttpGet("/GetCategory/{categoryId}")]
        public async Task<IActionResult> GetCategory(int categoryId)
        {
            Category category = await _categoryService.GetAsync(x => x.Id == categoryId);
            if (category == null)
            {
                return NotFound(Sonuc<CategoryDTOResponse>.SuccessNoDataFound());
            }

            CategoryDTOResponse categoryDTOResponse = _mapper.Map<CategoryDTOResponse>(category);

            Log.Information("Categories => {@categoryDTOResponse} => { Kategori Getirildi. }", categoryDTOResponse);

            return Ok(Sonuc<CategoryDTOResponse>.SuccessWithData(categoryDTOResponse));
        }
        [Authorize(Roles = "Admin,Satın Alma Personeli,Satın Alma Departman Müdürü,Şirket Müdürü,Yönetim Kurulu Başkanı")]
        [HttpGet("/GetCategories")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryService.GetAllAsync(x=>x.IsActive==true);
            if (categories == null)
            {
                return NotFound(Sonuc<CategoryDTOResponse>.SuccessNoDataFound());
            }
            List<CategoryDTOResponse> categoryDTOResponseList = new();
            foreach (var category in categories)
            {
                categoryDTOResponseList.Add(_mapper.Map<CategoryDTOResponse>(category));
            }

            Log.Information("Categories => {@categoryDTOResponse} => { Kategoriler Getirildi. }", categoryDTOResponseList);

            return Ok(Sonuc<List<CategoryDTOResponse>>.SuccessWithData(categoryDTOResponseList));
        }
    }
}
