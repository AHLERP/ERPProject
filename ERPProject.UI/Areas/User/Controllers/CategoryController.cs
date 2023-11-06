using ERPProject.Entity.DTO.CategoryDTO;
using Microsoft.AspNetCore.Mvc;

namespace ERPProject.UI.Areas.User.Controllers
{
    [Area("User")]
    public class CategoryController : BaseController
    {
        private readonly string url = "https://localhost:7075/";
        public CategoryController(HttpClient httpClient) : base(httpClient)
        {

        }
        [HttpGet("/User/Kategoriler")]
        public async Task<IActionResult> Index()
        {
            var val = await GetAllAsync<CategoryDTOResponse>(url + "GetCategories");
            return View(val);
        }
        [HttpGet("/User/Kategori")]
        public async Task<IActionResult> Get(long id)
        {
            var val = await GetAsync<CategoryDTOResponse>(url + "GetCategory/" + id);
            return View(val);
        }
        [HttpPost("/User/KategoriEkle")]
        public async Task<IActionResult> Add(CategoryDTORequest p)
        {
            var response = await AddAsync(p, url + "AddCategory");
            if (response)
            {
                return RedirectToAction("Index", "Category");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/User/KategoriGuncelle")]
        public async Task<IActionResult> Update(CategoryDTORequest p)
        {
            var response = await UpdateAsync(p, url + "UpdateCategory");
            if (response)
            {
                return RedirectToAction("Index", "Category");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/User/KategoriSil")]
        public async Task<IActionResult> Delete(long id)
        {
            var response = await DeleteAsync(url + "RemoveCategory/" + id);
            if (response)
            {
                return RedirectToAction("Index", "Category");

            }
            return RedirectToAction("Index", "Home");

        }
    }
}
