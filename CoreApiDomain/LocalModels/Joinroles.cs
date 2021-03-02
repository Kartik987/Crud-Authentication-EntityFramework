using System;


namespace CoreApiDomain.LocalModels
{
   public class Joinroles
    {

        public int RoleId { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string UseRoles { get; set; }
        
    }
}
