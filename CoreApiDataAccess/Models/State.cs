using System;
using System.Collections.Generic;

#nullable disable

namespace CoreApiDataAccess.Models
{
    public partial class State
    {
        public short StateId { get; set; }
        public string StateName { get; set; }
        public short? CountryId { get; set; }
    }
}
