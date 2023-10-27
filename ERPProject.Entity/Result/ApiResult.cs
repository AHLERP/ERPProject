using ERPProject.Entity.Result;

namespace ERPProject.Entity.Result
{

    public class ApiResult<T>
    {
        public int StatusCode { get; }
        public string Mesaj { get; set; }

        public HataBilgisi HataBilgisi { get; set; }

        public T Data { get; set; }


        public ApiResult(T data, int statustCode, HataBilgisi hataBilgisi, string mesaj)
        {
            StatusCode = statustCode;
            HataBilgisi = hataBilgisi;
            Mesaj = mesaj;
            Data = data;
        }

    }

}
