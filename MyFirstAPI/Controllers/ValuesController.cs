using CoreAPIBuisnessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using CoreApiDataAccess.Models;
namespace MyFirstAPI.Controllers
{
    [ApiController]
    
    public class ValuesController : ControllerBase
    {

        private readonly IUser _user;

        public ValuesController(IUser user)
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
        [Route("api/[controller]/{Id}")]
        public IActionResult Getuser(Guid Id)
        {
            var user = _user.GetUser(Id);
           
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound("User id " + Id + " not found");

            }

        }
        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult Adduser(Usermodel user)
        {

            _user.CreateUser(user);

            return Ok(user);  

        }

        [HttpDelete]
        [Route("api/[controller]/{Id}")]
        public IActionResult Deleteuser(Guid Id)
        {
            var user = _user.GetUser(Id);
            if (user != null)
            {

                _user.DeleteUser(user);
                return Ok();
            }
            else
            {
                return NotFound("User not found");

            }

        }

        [HttpPatch]
        [Route("api/[controller]/{Id}")]
        public IActionResult Updateuser(Guid Id, Usermodel newusr)
        {
            var user = _user.GetUser(Id);
            if (user != null)
            {
                newusr.ID = user.ID;
                _user.UpdateUser(newusr);
                return Ok(newusr);
            }
            else
            {
                return NotFound("User not found");

            }

        }



    }
}
