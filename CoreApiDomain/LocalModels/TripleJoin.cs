using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApiDomain.LocalModels
{
   public class TripleJoin
    {

        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string UserRole { get; set; }
        public int Roleid { get; set; }
        public string UserAccess { get; set; }
    }
}
