using CoreAPIBuisnessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using CoreApiDataAccess.Models;
using System.Linq;

namespace CoreAPIBuisnessLayer.Service
{
  public  class Uservice:IUser
    {
       public List<Usermodel> usermodel = new List<Usermodel>()
            {
                new Usermodel(){ Name = "User1", ID = Guid.NewGuid() },
                new Usermodel(){ Name = "User2", ID = Guid.NewGuid() },
                new Usermodel(){ Name = "User3", ID = Guid.NewGuid() }

            };
        
        public Usermodel GetUser(Guid Id)
        {
            return usermodel.SingleOrDefault(x => x.ID == Id);
        }

        public Usermodel UpdateUser(Usermodel us)
        {
            var curr = GetUser(us.ID);
            curr.Name = us.Name;
            return curr;
        }
        public Usermodel CreateUser(Usermodel user)
        {
            user.ID = Guid.NewGuid();
            usermodel.Add(user);
            return user;
        }

        public void DeleteUser(Usermodel user)
        {
            usermodel.Remove(user);
           
        }

        public List<Usermodel> Getalluser()
        {
            return usermodel;
        }
    }
}
