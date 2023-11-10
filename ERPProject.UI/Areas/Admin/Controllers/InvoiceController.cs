﻿using ClosedXML.Excel;
using ERPProject.Entity.DTO.InvoiceDTO;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ERPProject.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InvoiceController : BaseController
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        private readonly string url = "https://localhost:7075/";
        public InvoiceController(HttpClient httpClient, IWebHostEnvironment hostingEnvironment) : base(httpClient)
        {
            _hostingEnvironment = hostingEnvironment;

        }
        [HttpGet("/Admin/Faturalar")]
        public async Task<IActionResult> Index()
        {
            var val = await GetAllAsync<InvoiceDTOResponse>(url + "GetInvoices");
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
        [HttpGet("/Admin/Fatura")]
        public async Task<IActionResult> Get(long id)
        {
            var val = await GetAsync<InvoiceDTOResponse>(url + "GetInvoice/" + id);
            return View(val);
        }
        [HttpPost("/Admin/FaturaEkle")]
        public async Task<IActionResult> Add(IFormFile FileUpload)
        {
            if (FileUpload != null)
            {
                System.Data.DataTable dt = new System.Data.DataTable();

                // excel dosyamızı stream'e çeviriyoruz
                using (var ms = new MemoryStream())
                {
                    FileUpload.CopyTo(ms);

                    // excel dosyamızı streamden okuyoruz
                    using (var workbook = new XLWorkbook(ms))
                    {
                        var worksheet = workbook.Worksheet(1); // sayfa 
                        // sayfada kaç sütun kullanılmış onu buluyoruz ve sütunları DataTable'a ekliyoruz, ilk satırda sütun başlıklarımız var
                        int i, n = worksheet.Columns().Count();
                        for (i = 1; i <= n; i++)
                        {
                            dt.Columns.Add(worksheet.Cell(1, i).Value.ToString());
                        }

                        // sayfada kaç satır kullanılmış onu buluyoruz ve DataTable'a satırlarımızı ekliyoruz
                        n = worksheet.Rows().Count();
                        for (i = 2; i <= n; i++)
                        {
                            DataRow dr = dt.NewRow();

                            int j, k = worksheet.Columns().Count();
                            for (j = 1; j <= k; j++)
                            {
                                // i= satır index, j=sütun index, closedXML worksheet için indexler 1'den başlıyor, ama datatable için 0'dan başladığı için j-1 diyoruz
                                dr[j - 1] = worksheet.Cell(i, j).Value;
                            }

                            dt.Rows.Add(dr);
                        }
                        InvoiceDTORequest dTORequest=null;
                        n = dt.Rows.Count;
                        for (i = n; i <= n ; i++)
                        {
                            DataRow row = dt.Rows[i];
                            dTORequest = new InvoiceDTORequest
                            {
                                SupplierName = row["Tedarikci"].ToString(),
                                CompanyName = row["Şirket"].ToString(),
                                TotalPrice = Convert.ToInt32(row["ToplamFiyat"]),
                                InvoiceDate = Convert.ToDateTime(row["Tarih"])
                            };
                            var val = await AddAsync(dTORequest, url + "AddInvoice");
                        }
                        
                        for (i = 0; i < n-1; i++)
                        {
                            DataRow row = dt.Rows[i];
                             dTORequest = new InvoiceDTORequest
                            {
                                SupplierName = row["Tedarikci"].ToString(),
                                CompanyName = row["Şirket"].ToString(),
                                TotalPrice = Convert.ToInt32(row["Fiyat"]), 
                                InvoiceDate = Convert.ToDateTime(row["Tarih"])
                            };
                            var val = await AddAsync(dTORequest, url + "AddInvoice");
                        }
                            
                        //if (val)
                        //{
                        //    return RedirectToAction("Index", "Invoice");

                        //}
                        return RedirectToAction("Index", "Invoice");                     
        }
        [HttpPost("/Admin/FaturaGuncelle")]
        public async Task<IActionResult> Update(InvoiceDTORequest p)
        {
            var val = await UpdateAsync(p, url + "UpdateInvoice");
            if (val)
            {
                return RedirectToAction("Index", "Invoice");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/Admin/FaturaSil")]
        public async Task<IActionResult> Delete(long id)
        {
            var val = await DeleteAsync(url + "RemoveInvoice/" + id);
            if (val)
            {
                return RedirectToAction("Index", "Invoice");

            }
            return RedirectToAction("Index", "Home");

        }
    }
}
