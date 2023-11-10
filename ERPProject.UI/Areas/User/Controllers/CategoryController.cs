using ERPProject.Entity.DTO.CategoryDTO;
using ERPProject.Entity.Poco;
using ERPProject.UI.Areas.User.Models;
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
        [HttpGet("/Kullanici/Kategoriler")]
        public async Task<IActionResult> Index()
        {
            var val = await GetAllAsync<CategoryDTOResponse>(url + "GetCategories");
            if (val.StatusCode == 401)
            {
                return RedirectToAction("Unauthorized", "Home");
            }
            else if (val.StatusCode == 403)
            {
                return RedirectToAction("Forbidden", "Home");
            }
            return View(val);
        }
        [HttpGet("/Kullanici/Kategori")]
        public async Task<IActionResult> Get(long id)
        {
            var val = await GetAsync<CategoryDTOResponse>(url + "GetCategory/" + id);
            return View(val);
        }
        [HttpPost("/Kullanici/KategoriEkle")]
        public async Task<IActionResult> Add(CategoryDTORequest p)
        {
            var val = await AddAsync(p, url + "AddCategory");
            if (val.Data != null)
            {
                return RedirectToAction("Index", "Category");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/Kullanici/KategoriGuncelle")]
        public async Task<IActionResult> Update(CategoryDTORequest p)
        {
            var val = await UpdateAsync(p, url + "UpdateCategory");
            if (val)
            {
                return RedirectToAction("Index", "Category");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpGet("/Kullanici/KategoriSil/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var val = await DeleteAsync(url + "RemoveCategory/" + id);
            if (val)
            {
                return RedirectToAction("Index", "Category");

            }
            return RedirectToAction("Index", "Home");

        }
    }
}
