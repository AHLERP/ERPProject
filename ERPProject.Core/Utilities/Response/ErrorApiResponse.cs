using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Core.Utilities.Response
{
    public class ErrorApiResponse : ApiResponse
    {
        public ErrorApiResponse() : base(success: false)
        {

        }
        public ErrorApiResponse(string message) : base(success: false, message: message)
        {

        }
    }
}
