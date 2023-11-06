﻿using ERPProject.Entity.DTO.StockDTO;
using Microsoft.AspNetCore.Mvc;

using ERPProject.Entity.DTO.StockDTO;
using Microsoft.AspNetCore.Mvc;

namespace ERPProject.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StockController : BaseController
    {
        private readonly string url = "https://localhost:7075/";
        public StockController(HttpClient httpClient) : base(httpClient)
        {

        }
        [HttpGet("/Admin/Stoklar")]
        public async Task<IActionResult> Index()
        {
            var val = await GetAllAsync<StockDTOResponse>(url + "GetStocks");
            return View(val);
        }
        [HttpGet("/Admin/Stok")]
        public async Task<IActionResult> Get(long id)
        {
            var val = await GetAsync<StockDTOResponse>(url + "GetStock/" + id);
            return View(val);
        }
        [HttpPost("/Admin/StokEkle")]
        public async Task<IActionResult> Add(StockDTORequest p)
        {
            var response = await AddAsync(p, url + "AddStock");
            if (response)
            {
                return RedirectToAction("Index", "Stock");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/Admin/StokGuncelle")]
        public async Task<IActionResult> Update(StockDTORequest p)
        {
            var response = await UpdateAsync(p, url + "UpdateStock");
            if (response)
            {
                return RedirectToAction("Index", "Stock");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/Admin/StokSil")]
        public async Task<IActionResult> Delete(long id)
        {
            var response = await DeleteAsync(url + "RemoveStock/" + id);
            if (response)
            {
                return RedirectToAction("Index", "Stock");

            }
            return RedirectToAction("Index", "Home");

        }
    }
}
