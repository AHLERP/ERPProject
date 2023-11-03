using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Core.Utilities.Response
{
    public class SuccessApiDataResponse<T> : ApiDataResponse<T>
    {
        public SuccessApiDataResponse(T data) : base(success: true)
        {
            Data = data;
        }
        public SuccessApiDataResponse(T data, string message) : base(success: true, message: message)
        {
            Data = data;
        }
    }
}
