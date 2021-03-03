using CoreAPIBuisnessLayer.Interfaces;
using CoreApiDataAccess.Models;
using CoreApiDomain.LocalModels;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace CoreAPIBuisnessLayer.Service
{
   public class Jwtservices: IJwtInterface
    {

        private readonly string key;
        public Jwtservices(string key)
        {
            this.key = key;
        }

        public Tokendisp Authenticate(string username, string password)
        {

            EncryptDecrypt ed = new EncryptDecrypt();
            ed.Password = password;
            var encryptpswd = ed.getencrypt;
            var context = new UserContext();
            Authentication usrtbl = context.Authentications.Where(auth => auth.Username == username).Where(auth => auth.Password == encryptpswd).FirstOrDefault();
          
            Tokendisp tokenshow = new Tokendisp();
            try
            {

                if (usrtbl != null)
                {
                   // Console.WriteLine("Hey i am here at 1");
                    var tokenhandler = new JwtSecurityTokenHandler();
                    var tokenkey = Encoding.ASCII.GetBytes(key);
                  //  Console.WriteLine("Hey i am here at 2");

                    var tokendesc = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[] {

                            new Claim(ClaimTypes.Name, "")
                        }),
                          
                        Expires = new DateTimeOffset(DateTime.Now.AddMinutes(5)).DateTime,
                        SigningCredentials = new SigningCredentials(
                            new SymmetricSecurityKey(tokenkey),
                            SecurityAlgorithms.HmacSha256Signature     
                            ),
                    };
                    // Console.WriteLine("Hey i am here at 3");

                    var token = tokenhandler.CreateToken(tokendesc);
                    usrtbl.Token = tokenhandler.WriteToken(token);
                    tokenshow.Username = usrtbl.Username;
                    tokenshow.Token = usrtbl.Token;
                    tokenshow.Expires = tokendesc.Expires.Value;
                    context.SaveChanges();
                  
                    return tokenshow;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("User not found " + e.GetType());

            }


            return null;
        }

        public Authentication Addauthuser(Authmodel authobj)
        {
            Authentication usertbl = new Authentication();

            using (var context = new UserContext())
            {
                EncryptDecrypt ed = new EncryptDecrypt();

                usertbl.Username = authobj.Username;
                ed.Password = authobj.Password;
                usertbl.Password = ed.getencrypt;
                usertbl.Token = "";
                context.Authentications.Add(usertbl);
                context.SaveChanges();

                return usertbl;
            }



        }
    }
}
