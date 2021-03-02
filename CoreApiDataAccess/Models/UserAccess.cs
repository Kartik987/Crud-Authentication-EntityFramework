using System;
using System.Collections.Generic;

#nullable disable

namespace CoreApiDataAccess.Models
{
    public partial class UserAccess
    {
        public int RoleId { get; set; }
        public Guid Userid { get; set; }
        public string Access { get; set; }

        public virtual UserEntityTable User { get; set; }
    }
}
