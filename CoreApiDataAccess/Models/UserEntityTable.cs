using System;
using System.Collections.Generic;

#nullable disable

namespace CoreApiDataAccess.Models
{
    public partial class UserEntityTable
    {
        public UserEntityTable()
        {
            UserAccesses = new HashSet<UserAccess>();
            UserRoles = new HashSet<UserRole>();
        }

        public Guid Userid { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserAccess> UserAccesses { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
