using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Core.Utilities.Security.Token
{
    public interface ITokenService
    {
        AccessToken CreateToken(long userId, string userName, int roleId);
    }
}
