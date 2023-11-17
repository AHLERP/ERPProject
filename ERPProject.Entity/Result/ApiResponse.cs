using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Entity.Result
{
    public class ApiResponse<T>
    {
        public int? StatusCode { get; set; }
        public string? Mesaj { get; set; }

        public HataBilgisi? HataBilgisi { get; set; }

        public T? Data { get; set; }


        public ApiResponse(T data, int statustCode, HataBilgisi hataBilgisi, string mesaj)
        {
            StatusCode = statustCode;
            HataBilgisi = hataBilgisi;
            Mesaj = mesaj;
            Data = data;
        }  
       

       
    }
}
