using System;
using System.Collections.Generic;

#nullable disable

namespace CoreApiDataAccess.Models
{
    public partial class Authentication
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
