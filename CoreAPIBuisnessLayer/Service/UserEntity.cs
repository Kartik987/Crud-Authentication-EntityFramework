using System;
using System.Collections.Generic;
using CoreApiDataAccess.Models;
using CoreApiDomain.LocalModels;
using System.Linq;
using CoreAPIBuisnessLayer.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace CoreAPIBuisnessLayer.Service
{
   public class UserEntity:IUserEntity
    {

        private readonly Dictionary<int, string> Pairs = new Dictionary<int, string>();
       
        
        public Dictionary<int, string> Getroles()
        {

           
            Pairs[105] = "Associate";
            Pairs[302] = "Mentor";
            Pairs[204] = "Analyst";
            Pairs[402] = "Manager";
            Pairs[110] = "Lead";
            return Pairs;
        }

      
        public List<UserEntityTable> Getalluser()
        {

           var context = new UserContext();
            return context.UserEntityTables.ToList();

        }

        public List<Joinroles> GetuserwithrolesInner()
        {
           
            using (var context = new UserContext())
            {
                var abc = (from p in context.UserEntityTables
                          join e in context.UserRoles
                          on p.Userid equals e.Userid
                          select new Joinroles
                          {
                              RoleId = e.Roleid,
                              UserId = p.Userid,
                              Name = p.Name,
                              UseRoles = e.Roles
                          }).ToList();

                return abc;
            }

        }
        
        public List<LojOuter> GetuserwithrolesLOJ()
        {
          
            using (var context = new UserContext())
            {
                var abc = (from p in context.UserEntityTables
                           join e in context.UserRoles
                           on p.Userid equals e.Userid into Details
                           from m in Details.DefaultIfEmpty()
                           select new LojOuter
                           {
                             
                               UserId = p.Userid,
                               Name = p.Name,
                               UseRoles =m.Roles,
     
                           }).ToList();

                return abc;
            }

        }
        public List<Jointech> GetuserwithTechInner()
        {

            using (var context = new UserContext())
            {
                var abc = (from p in context.UserEntityTables
                           join e in context.UserTeches
                           on p.Userid equals e.Userid
                           select new Jointech
                           {
                               UserId = p.Userid,
                               Name = p.Name,
                               UseTech = e.Tech
                           }).ToList();

                return abc;
            }

        }

        public List<Joinroles> GetuserwithrolesIDInner(Guid Id)
        {

            using (var context = new UserContext())
            {
                var abc = (from p in context.UserEntityTables
                           join e in context.UserRoles
                           on p.Userid equals e.Userid where p.Userid==Id
                           select new Joinroles
                           {
                               RoleId = e.Roleid,
                               UserId = p.Userid,
                               Name = p.Name,
                               UseRoles = e.Roles
                           }).ToList();

                return abc;
            }

        }


        public List<Jointech> GetuserwithTechIDInner(Guid Id)
        {

            using (var context = new UserContext())
            {
                
                var abc = (from p in context.UserEntityTables
                           join e in context.UserTeches
                           on p.Userid equals e.Userid
                           where p.Userid == Id
                           select new Jointech
                           {
                               UserId = p.Userid,
                               Name = p.Name,
                               UseTech = e.Tech
                           }).ToList();
              

               
                return abc;
            }

        }

        public bool JoinCreate(CreateUserJoin crtusr)
        {
            var mappair = Getroles();
            bool Usercheck = true;
            
            UserRole usertbl = new UserRole();

            using (var context = new UserContext())
            {
                try
                {
                    var UpdQuery = (from p in context.UserEntityTables
                                    join e in context.UserRoles
                                    on p.Userid equals e.Userid  into Details
                                    from m in Details.DefaultIfEmpty()
                                    where p.Userid == crtusr.Id
                                    select new
                                    {
                                        p,
                                        m

                                    }).FirstOrDefault();

                    if(UpdQuery != null)
                    {
                            usertbl.Userid = crtusr.Id;
                            usertbl.Roleid = crtusr.RollId;

                            if (mappair.ContainsKey(crtusr.RollId))
                            {
                                usertbl.Roles = mappair[crtusr.RollId];
                            }
                            context.UserRoles.Add(usertbl);
                        
                    }
                    else
                    {
                        Usercheck = false;
                        throw new Exception();
                    }
  
                    
                }
                catch(Exception e)
                {
                   if(e is InvalidOperationException)

                        Console.WriteLine("Duplicate entry Found " + e.GetType());

                    else
                        Console.WriteLine("User not Found " + e.GetType());

                    return Usercheck;
                }
                

                context.SaveChanges();

                return Usercheck;

            }

        }

        public bool JoinUpdate(Updateuseraccess usraccs)
        {

            bool userexist = false;
            using (var context = new UserContext())
            {

                try {
                    var UpdQuery = (from p in context.UserEntityTables
                                    join e in context.UserAccesses on p.Userid equals e.Userid
                                    where p.Userid == usraccs.Id && e.RoleId == usraccs.Rollid
                                    select new
                                    {
                                        p,
                                        e

                                    }).FirstOrDefault();
                    if (UpdQuery == null)
                        return userexist;
                    else
                        userexist = true;
                    UpdQuery.e.Access = usraccs.Access;

                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Failed Update, User not found " + e.GetType());
                }

                return userexist;
            }

        }


        public bool JoinDelete(DeleteUserRole Deleterole)
        {
            bool userexist = false;
            using (var context = new UserContext())
            {
                
                try
                {

                    UserRole obj = new UserRole();

                    obj = (from p in context.UserEntityTables
                           join e in context.UserRoles on p.Userid equals e.Userid
                           where p.Userid == Deleterole.Id && e.Roleid == Deleterole.roleId
                           select new UserRole
                           {
                               Userid = p.Userid,
                               Roleid = e.Roleid,
                               Roles = e.Roles

                           }).FirstOrDefault();
                    if (obj is null)
                        return userexist;
                    else
                        userexist = true;
                    context.UserRoles.Remove(obj);

                    context.SaveChanges();

                }
               catch(Exception e)
                {

                    Console.WriteLine("User Not Found:" + e.GetType());
                }

                return userexist;

            }

        }
       

        public UserEntityTable Adduser(string Name)
        {
            UserEntityTable usertbl = new UserEntityTable();
          
            using (var context = new UserContext())
            {
                using var transaction = context.Database.BeginTransaction();

                try {

                    usertbl.Userid = Guid.NewGuid();
                    usertbl.Name = Name;
                    context.UserEntityTables.Add(usertbl);
                    context.SaveChanges();

                    if (string.IsNullOrWhiteSpace(Name))
                        throw new Exception();

                    usertbl.Userid = Guid.NewGuid();
                    usertbl.Name = Name + "$";
                    context.UserEntityTables.Add(usertbl);
                    context.SaveChanges();


                    transaction.Commit();
                    return usertbl;
                }
                catch(Exception e)
                {
                    transaction.Rollback();
                    Console.WriteLine("Rollback Exception:- " + e.GetType());
                    return usertbl;
                }

                   
                }

       
                    
            }

        

        
        public List<TripleJoin> Userrole_access()
        {
            using (var context = new UserContext())
            {

        
               var result = (
                              from p in context.UserEntityTables
                              join e in context.UserRoles on p.Userid equals e.Userid
                              join w in context.UserAccesses on e.Roleid equals w.RoleId
                              where e.Userid==w.Userid && e.Roleid ==w.RoleId
                              select new TripleJoin

                              {
                                  UserId = p.Userid,
                                  Name = p.Name,
                                  UserRole = e.Roles,
                                  Roleid = e.Roleid,
                                  UserAccess = w.Access

                              }).Distinct().DefaultIfEmpty();

                /*var Query = from e in context.UserEntityTables
                            from l in context.UserRoles
                            join p in context.UserAccesses
                            on e.Userid equals l.Userid 
                            select new { e.Userid, l.Roleid,l.Roles, p.Access };*/

                return result.ToList();
            }

        }

        public List<Jointech> Userrole_tech()
        {
            using (var context = new UserContext())
            {
                var result = (
                              from p in context.UserEntityTables
                              join e in context.UserRoles on p.Userid equals e.Userid
                              join w in context.UserTeches on p.Userid equals w.Userid
                              select new Jointech
                              {
                                 UserId= p.Userid,
                                  Name = p.Name,
                                   UseTech  =w.Tech

                              }).Distinct().DefaultIfEmpty().ToList();
              


                /*var Query = from e in context.UserEntityTables
                            from l in context.UserRoles
                            join p in context.UserAccesses
                            on e.Userid equals l.Userid 
                            select new { e.Userid, l.Roleid,l.Roles, p.Access };*/

                return result;
            }

        }

        public UserEntityTable Getuser(Guid Id)
        {
            using (var context = new UserContext())
            {

                UserEntityTable usrtbl = new UserEntityTable();
              
                    
                    usrtbl = context.UserEntityTables.Where(auth => auth.Userid == Id).SingleOrDefault();

                return usrtbl;
            }


            /*if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound("User id " + Id + " not found");

            }*/

        }

        public List<UserEntityTable> Updateuser(Guid Id, string Name)
        {
            using (var context = new UserContext())
            {
                UserEntityTable usrtbl = context.UserEntityTables.Where(auth => auth.Userid == Id).FirstOrDefault();
                usrtbl.Name = Name;
                context.SaveChanges();
                return context.UserEntityTables.Where(auth => auth.Name == Name).ToList();



            }

        }

        public UserEntityTable Deleteuser(Guid Id)
        {
            using (var context = new UserContext())
            {
                UserEntityTable usrtbl = context.UserEntityTables.Where(auth => auth.Userid == Id).FirstOrDefault();
                UserEntityTable usrdelete = new UserEntityTable();
                if (usrtbl != null) {

                    usrdelete = usrtbl;
                    context.UserEntityTables.Remove(usrtbl);
                    context.SaveChanges();
      
                }

                return usrdelete;




            }

        }


       




        /*   authentication  function*/

       /* public List<UserEntityTable> Showdata(Guid token)
        {
            using (var context = new UserContext())
            {

                Authentication userauth = new Authentication();

             

                var abc = (from p in context.Authentications
                           
                           select new 
                           {
                              
                              p.Token,
                              
                           }).ToList();

                foreach(var x in abc)
                {
                    if (x.Equals(token) )
                    {
                        return context.UserEntityTables.ToList();
                    }
                }

                return context.UserEntityTables.Where(auth=>auth.Name=="jojo").ToList();


            }
        }*/


        /*   authentication  function*/


    }
}
