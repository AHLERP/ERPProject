﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Core.CustomException
{
    public class TokenNotFoundException:Exception
    {
        public TokenNotFoundException(string message = "Token Bilgisi Gelmedi") : base(message)
        {

        }
    }
}
