using CoreAPIBuisnessLayer.Interfaces;
using CoreApiDomain.LocalModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MyFirstAPI.Controllers
{

    
    public class Tokencontroller : Controller
    {
        private readonly IJwtInterface _user;

        public Tokencontroller(IJwtInterface user)
        {

            _user = user;
        }
        [Authorize]
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]Authmodel authobj)
        {

          var token =   _user.Authenticate(authobj.Username, authobj.Password);

            if (token != null)
                return Ok(token);
            else
                return Unauthorized();
        }


        [HttpPost]
        [Route("AddauthUser")]
        public IActionResult AuthuserAdd([FromBody] Authmodel authobj)
        {
            return Ok(_user.Addauthuser(authobj));

        }

        [Authorize]
        [HttpGet("AuthenticatedUser")]
        
        public IActionResult Getvalues()
        {
           
            return Ok("User is authenticated " );
        }
    }
}
