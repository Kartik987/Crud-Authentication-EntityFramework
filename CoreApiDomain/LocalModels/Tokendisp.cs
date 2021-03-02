using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApiDomain.LocalModels
{
  public   class Tokendisp
    {

        public string Username { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }
    }
}
