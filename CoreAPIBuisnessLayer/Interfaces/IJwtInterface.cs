using CoreApiDataAccess.Models;
using CoreApiDomain.LocalModels;
using System.Collections.Generic;
using System;

namespace CoreAPIBuisnessLayer.Interfaces
{
   public interface IJwtInterface
    {

        Authentication Addauthuser(Authmodel authobj);
     Tokendisp Authenticate(string username, string password);
    }
}
