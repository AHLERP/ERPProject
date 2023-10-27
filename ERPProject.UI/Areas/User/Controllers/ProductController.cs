using ERPProject.Entity.DTO.ProductDTO;
using Microsoft.AspNetCore.Mvc;

namespace ERPProject.UI.Areas.User.Controllers
{
    [Area("Admin")]
    public class ProductController : BaseController
    {
        private readonly string url = "https://localhost:7075/";
        public ProductController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {

        }
        [HttpGet("/Admin/Ürünler")]
        public async Task<IActionResult> Index()
        {
            var val = await GetAllAsync<ProductDTOResponse>(url + "GetProducts");
            return View(val);
        }
        [HttpGet("/Admin/Ürün")]
        public async Task<IActionResult> Get(long id)
        {
            var val = await GetAsync<ProductDTOResponse>(url + "GetProduct/" + id);
            return View(val);
        }
        [HttpPost("/Admin/ÜrünEkle")]
        public async Task<IActionResult> Add(ProductDTORequest p)
        {
            var response = await AddAsync(p, url + "AddProduct");
            if (response)
            {
                return RedirectToAction("Index", "Product");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/Admin/ÜrünGüncelle")]
        public async Task<IActionResult> Update(ProductDTORequest p)
        {
            var response = await UpdateAsync(p, url + "UpdateProduct");
            if (response)
            {
                return RedirectToAction("Index", "Product");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/Admin/ÜrünSil")]
        public async Task<IActionResult> Delete(long id)
        {
            var response = await DeleteAsync(url + "RemoveProduct/" + id);
            if (response)
            {
                return RedirectToAction("Index", "Product");

            }
            return RedirectToAction("Index", "Home");

        }
    }
}
