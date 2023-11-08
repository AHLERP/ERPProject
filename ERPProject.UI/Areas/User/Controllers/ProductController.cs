﻿using ERPProject.Entity.DTO.BrandDTO;
using ERPProject.Entity.DTO.CategoryDTO;
using ERPProject.Entity.DTO.CompanyDTO;
using ERPProject.Entity.DTO.OfferDTO;
using ERPProject.Entity.DTO.ProductDTO;
using ERPProject.Entity.Poco;
using ERPProject.UI.Areas.User.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERPProject.UI.Areas.User.Controllers
{
    [Area("User")]
    public class ProductController : BaseController
    {
        private readonly string url = "https://localhost:7075/";
        public ProductController(HttpClient httpClient) : base(httpClient)
        {

        }
        [HttpGet("/Kullanici/Urunler")]
        public async Task<IActionResult> Index()
        {
            var val = await GetAllAsync<ProductDTOResponse>(url + "GetProducts");
            var val2 = await GetAllAsync<BrandDTOResponse>(url + "GetBrands");
            var val3 = await GetAllAsync<CategoryDTOResponse>(url + "GetCategories");
            if (val.StatusCode == 401)
            {
                return RedirectToAction("Unauthorized", "Home");
            }
            else if (val.StatusCode == 403)
            {
                return RedirectToAction("Forbidden", "Home");
            }
            ProductVM productVM = new ProductVM()

            {
                Products = val.Data,
                Brands= val2.Data,
                Categories= val3.Data,
            };
            return View(productVM);
        }
        [HttpGet("/Kullanici/Urun")]
        public async Task<IActionResult> Get(long id)
        {
            var val = await GetAsync<ProductDTOResponse>(url + "GetProduct/" + id);
            return View(val);
        }
        [HttpPost("/Kullanici/UrunEkle")]
        public async Task<IActionResult> Add(ProductDTORequest p)
        {
            var val = await AddAsync(p, url + "AddProduct");
            if (val)
            {
                return RedirectToAction("Index", "Product");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/Kullanici/UrunGuncelle")]
        public async Task<IActionResult> Update(ProductDTORequest p)
        {
            var val = await UpdateAsync(p, url + "UpdateProduct");
            if (val)
            {
                return RedirectToAction("Index", "Product");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpGet("/Kullanici/UrunSil/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var val = await DeleteAsync(url + "RemoveProduct/" + id);
            if (val)
            {
                return RedirectToAction("Index", "Product");

            }
            return RedirectToAction("Index", "Home");

        }
    }
}