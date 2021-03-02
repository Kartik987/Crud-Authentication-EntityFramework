using System;
using System.Collections.Generic;
using CoreApiDataAccess.Models;
using CoreApiDomain.LocalModels;
using System.Linq;
namespace CoreAPIBuisnessLayer.Interfaces
{
    public interface IUserEntity
    {

        public List<UserEntityTable> Getalluser();
        public UserEntityTable Adduser(string Name);
        public UserEntityTable Getuser(Guid Id);
        public List<UserEntityTable> Updateuser(Guid Id, string Name);
        public UserEntityTable Deleteuser(Guid Id);
        public List<Joinroles> GetuserwithrolesInner();
        public List<LojOuter> GetuserwithrolesLOJ();
        public List<Joinroles> GetuserwithrolesIDInner(Guid Id);

        public List<Jointech> GetuserwithTechInner();
        public List<Jointech> GetuserwithTechIDInner(Guid Id);

        public List<TripleJoin> Userrole_access();

        public List<Jointech> Userrole_tech();

        public bool JoinUpdate(Updateuseraccess usraccs);

        public bool JoinDelete(DeleteUserRole Deleterole );

        public bool JoinCreate(CreateUserJoin crtusr);

        /* public Authentication Addauthuser(Authmodel authobj);


         public List<UserEntityTable> Showdata(Guid Token);*/

       
    
    
    }
}
