using System;
using System.Collections.Generic;
using System.Text;

namespace ApiAuthentication1.Application.DTOs
{
    public class LoginDTO
    {
        public string User { get; set; }
        public string Password { get; set; }
        public int ApplicationId { get; set; }
    }
}
