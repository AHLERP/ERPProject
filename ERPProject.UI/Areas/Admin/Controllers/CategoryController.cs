﻿using ERPProject.Entity.DTO.CategoryDTO;
using Microsoft.AspNetCore.Mvc;

namespace ERPProject.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : BaseController
    {
        private readonly string url = "https://localhost:7075/";
        public CategoryController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {

        }
        [HttpGet("/Admin/Kategoriler")]
        public async Task<IActionResult> Index()
        {
            var val = await GetAllAsync<CategoryDTOResponse>(url + "GetCategories");
            return View(val);
        }
        [HttpGet("/Admin/Kategori")]
        public async Task<IActionResult> Get(long id)
        {
            var val = await GetAsync<CategoryDTOResponse>(url + "GetCategory/" + id);
            return View(val);
        }
        [HttpPost("/Admin/KategoriEkle")]
        public async Task<IActionResult> Add(CategoryDTORequest p)
        {
            var response = await AddAsync(p, url + "AddCategory");
            if (response)
            {
                return RedirectToAction("Index", "Category");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/Admin/KategoriGuncelle")]
        public async Task<IActionResult> Update(CategoryDTORequest p)
        {
            var response = await UpdateAsync(p, url + "UpdateCategory");
            if (response)
            {
                return RedirectToAction("Index", "Category");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/Admin/KategoriSil")]
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
