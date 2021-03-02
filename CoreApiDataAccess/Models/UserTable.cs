using System;
using System.Collections.Generic;

#nullable disable

namespace CoreApiDataAccess.Models
{
    public partial class UserTable
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }
        public string HomeAppl { get; set; }
        public string About { get; set; }
    }
}
