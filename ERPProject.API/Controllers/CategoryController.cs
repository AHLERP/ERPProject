using AutoMapper;
using ERPProject.Business.Abstract;
using ERPProject.Entity.DTO.CategoryDTO;
using ERPProject.Entity.Poco;
using ERPProject.Entity.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(IMapper mapper, ICategoryService categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        [HttpPost("/AddCategory")]
        public async Task<IActionResult> AddCategory(CategoryDTORequest categoryDTORequest)
        {
            Category category = _mapper.Map<Category>(categoryDTORequest);
            await _categoryService.AddAsync(category);

            CategoryDTOResponse categoryDTOResponse = _mapper.Map<CategoryDTOResponse>(category);
            return Ok(Sonuc<CategoryDTOResponse>.SuccessWithData(categoryDTOResponse));
        }
        [HttpDelete("/RemoveCategory/{categoryId}")]
        public async Task<IActionResult> RemoveCategory(int categoryId)
        {
            Category category = await _categoryService.GetAsync(x => x.Id == categoryId);
            if (category == null)
            {
                return NotFound(Sonuc<CategoryDTOResponse>.SuccessNoDataFound());
            }

            await _categoryService.RemoveAsync(category);
            return Ok(Sonuc<CategoryDTOResponse>.SuccessWithoutData());
        }

        [HttpPost("/UpdateCategory")]
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
            return Ok(Sonuc<CategoryDTOResponse>.SuccessWithData(categoryDTOResponse));
        }

        [HttpGet("/GetCategory/{categoryId}")]
        public async Task<IActionResult> GetCategory(int categoryId)
        {
            Category category = await _categoryService.GetAsync(x => x.Id == categoryId);
            if (category == null)
            {
                return NotFound(Sonuc<CategoryDTOResponse>.SuccessNoDataFound());
            }

            CategoryDTOResponse categoryDTOResponse = _mapper.Map<CategoryDTOResponse>(category);
            return Ok(Sonuc<CategoryDTOResponse>.SuccessWithData(categoryDTOResponse));
        }
    }
}
