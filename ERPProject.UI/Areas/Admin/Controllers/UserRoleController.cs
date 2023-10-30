﻿using ERPProject.Entity.DTO.UserRoleDTO;
using Microsoft.AspNetCore.Mvc;

namespace ERPProject.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserRoleController : BaseController
    {
        private readonly string url = "https://localhost:7075/";
        public UserRoleController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {

        }
        [HttpGet("/Admin/KullaniciRolleri")]
        public async Task<IActionResult> Index()
        {
            var val = await GetAllAsync<UserRoleDTOResponse>(url + "GetUserRoles");
            return View(val);
        }
        [HttpGet("/Admin/KullaniciRol")]
        public async Task<IActionResult> Get(long id)
        {
            var val = await GetAsync<UserRoleDTOResponse>(url + "GetUserRole/" + id);
            return View(val);
        }
        [HttpPost("/Admin/KullaniciRolEkle")]
        public async Task<IActionResult> Add(UserRoleDTORequest p)
        {
            var response = await AddAsync(p, url + "AddUserRole");
            if (response)
            {
                return RedirectToAction("Index", "UserRole");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/Admin/KullaniciRolGuncelle")]
        public async Task<IActionResult> Update(UserRoleDTORequest p)
        {
            var response = await UpdateAsync(p, url + "UpdateUserRole");
            if (response)
            {
                return RedirectToAction("Index", "UserRole");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/Admin/KullaniciRolSil")]
        public async Task<IActionResult> Delete(long id)
        {
            var response = await DeleteAsync(url + "RemoveUserRole/" + id);
            if (response)
            {
                return RedirectToAction("Index", "UserRole");

            }
            return RedirectToAction("Index", "Home");

        }
    }
}
