using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace DALnew.Models
{
    public class JWTHelper
    {
        public string JWTSecretKey { get; set; }

        public SymmetricSecurityKey GetSecretKey() =>
             new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JWTSecretKey));
    }
}
