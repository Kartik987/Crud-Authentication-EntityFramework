using System;
using System.Collections.Generic;
using System.Text;
using CoreApiDataAccess.Models;
namespace CoreAPIBuisnessLayer.Interfaces
{
    public interface IUser
    {

        List<Usermodel> Getalluser();
        Usermodel GetUser(Guid Usermodel);

        Usermodel CreateUser(Usermodel user);
        Usermodel UpdateUser(Usermodel user);

        void DeleteUser(Usermodel user);
    }
}
