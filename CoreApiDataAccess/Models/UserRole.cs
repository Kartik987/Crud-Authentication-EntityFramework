using System;
using System.Collections.Generic;

#nullable disable

namespace CoreApiDataAccess.Models
{
    public partial class UserRole
    {
        public Guid Userid { get; set; }
        public int Roleid { get; set; }
        public string Roles { get; set; }

        public virtual UserEntityTable User { get; set; }
    }
}
