using ERPProject.Entity.DTO.ProductDTO;
using Microsoft.AspNetCore.Mvc;

namespace ERPProject.UI.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        private readonly string url = "";
        public ProductController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {

        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var val = await GetAllAsync<ProductDTOResponse>(url);
            return View(val);
        }
        [HttpGet]
        public async Task<IActionResult> Get(long id)
        {
            var val = await GetAsync<ProductDTOResponse>(url + id);
            return View(val);
        }
        [HttpPost]
        public async Task<IActionResult> Add(ProductDTORequest p)
        {
            var response = await AddAsync(p, url);
            if (response)
            {
                return RedirectToAction("Index", "Product");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost]
        public async Task<IActionResult> Update(ProductDTORequest p)
        {
            var response = await UpdateAsync(p, url);
            if (response)
            {
                return RedirectToAction("Index", "Product");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost]
        public async Task<IActionResult> Delete(long id)
        {
            var response = await DeleteAsync(url + id);
            if (response)
            {
                return RedirectToAction("Index", "Product");

            }
            return RedirectToAction("Index", "Home");

        }
    }
}
