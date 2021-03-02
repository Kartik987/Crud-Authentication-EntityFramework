using System;
using System.Collections.Generic;

#nullable disable

namespace CoreApiDataAccess.Models
{
    public partial class UserTech
    {
        public Guid? Userid { get; set; }
        public string Tech { get; set; }

        public virtual UserEntityTable User { get; set; }
    }
}
