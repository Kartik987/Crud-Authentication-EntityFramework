using System;
using System.Collections.Generic;

#nullable disable

namespace CoreApiDataAccess.Models
{
    public partial class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public short? StateId { get; set; }
    }
}
