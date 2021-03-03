
using Microsoft.AspNetCore.Mvc;
using CoreAPIBuisnessLayer.Interfaces;
using CoreApiDomain.LocalModels;
using System;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;

namespace MyFirstAPI.Controllers
{

    [ApiController]

    public class EntityController : ControllerBase
    {

        private readonly IUserEntity _user;

        public EntityController(IUserEntity user)
        {

            _user = user;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult Getalluser()
        {

            return Ok(_user.Getalluser());

        }
        [HttpGet]
        [Route("api/[controller]/MasterRole-InnerJoin")]
        public IActionResult Getuserwithroles()
        {

            return Ok(_user.GetuserwithrolesInner());

        }
        [HttpGet]
        [Route("api/[controller]/MasterRole-InnerJoin/{id}")]
        public IActionResult GetuserwithroleID(Guid id)
        {

            return Ok(_user.GetuserwithrolesIDInner(id));

        }

        
        [HttpGet]
        [Route("api/[controller]/MasterRoleAccess")]
        public IActionResult Userrole_access()
        {

            return Ok(_user.Userrole_access());

        }
        
        [HttpGet]
        [Route("api/[controller]/MasterRoleTech")]
        public IActionResult Userrole_tech()
        {

            return Ok(_user.Userrole_tech());

        }

        

     [HttpPatch]
        [Route("api/[controller]/UpdateUserAccess")]
        public IActionResult JoinUpdate(Updateuseraccess usraccs)
        {
           var userexist =  _user.JoinUpdate(usraccs);
            if (!userexist)
                return NotFound();
            return Ok();

        }
        [HttpDelete]
        [Route("api/[controller]/DeleteUserRole")]
        public IActionResult JoinDelete(DeleteUserRole usrrole)
        {
             var userexist = _user.JoinDelete(usrrole);
            if (!userexist)
                return NotFound();
            return Ok();
        }
        [HttpGet]
        [Route("api/[controller]/MasterRole-OuterJoin")]
        public IActionResult Getuserwithouter()
        {

            return Ok(_user.GetuserwithrolesLOJ());

        }

        [HttpGet]
        [Route("api/[controller]/MasterTech-Join")]
        public IActionResult GetuserwithTech()
        {

            return Ok(_user.GetuserwithTechInner());

        }

        [HttpGet]
        [Route("api/[controller]/MasterTech-Join/{id}")]
        public IActionResult GetuserwithTechID(Guid id)
        {

            return Ok(_user.GetuserwithTechIDInner(id));

        }


        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult Adduser([FromBody]string Name)
        {
            
            return Ok(_user.Adduser(Name));

        }





        [HttpPost]
        [Route("api/[controller]/AddRole")]
        public IActionResult JoinCreate(CreateUserJoin crtusr)
        {
            var Userexist = _user.JoinCreate(crtusr);

            if (!Userexist)
                return NotFound();

            return Ok();

        }

        

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult Getuser(Guid id)
        {
            return Ok(_user.Getuser(id));

        }


        [HttpPatch]
        [Route("api/[controller]/Update")]
        public IActionResult Updateuser([FromBody] ID id,string Name)
        {
            return Ok(_user.Updateuser(id.Id, Name));

        }

        [HttpDelete]
        [Route("api/[controller]/delete")]
        public IActionResult Deleteuser(ID id)
        {
            return Ok(_user.Deleteuser(id.Id));

        }

     


    }
}
