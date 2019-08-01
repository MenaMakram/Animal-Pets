using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PetsApi.Models;
using PetsDatabaseDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace PetsApi.Controllers
{
    public class AcountController : ApiController
    {
        [Route("api/Register")]
        [HttpPost]
        public IdentityResult Register([FromBody]UsersDto userDto)
        {
            #region MinaMakram
            //var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
            //var manager = new UserManager<ApplicationUser>(userStore);
            //var user = new ApplicationUser() { UserName = userDto.UserName, Email = userDto.Email, FirstName = userDto.FirstName, LastName = userDto.LastName, PhoneNumber = userDto.Phone };
            //user.FirstName = userDto.FirstName;
            //user.LastName = userDto.LastName;
            //manager.PasswordValidator = new PasswordValidator
            //{
            //    RequiredLength = 3
            //};
            //IdentityResult result = manager.Create(user, userDto.Password);
            //manager.AddToRoles(user.Id, userDto.TypeRegistration);
            //return result;

            //ApplicationDbContext context = new ApplicationDbContext();
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //} 
            #endregion
            AuthBusinessLayer auth = new AuthBusinessLayer();
            IdentityResult result = auth.Create(userDto);

            if (result.Succeeded)
            {

                return result;
            }
            return result;

        }
        [Authorize]
        [HttpGet]
        [Route("api/GetUserClaims")]
        public UsersDto GetUserClaims()
        {
            var identityClaims = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identityClaims.Claims;
            UsersDto model = new UsersDto()
            {
                UserName = identityClaims.FindFirst("Username").Value,
                Email = identityClaims.FindFirst("Email").Value,
                FirstName = identityClaims.FindFirst("FirstName").Value,
                LastName = identityClaims.FindFirst("LastName").Value,
                ID = identityClaims.FindFirst("Id").Value

            };
            return model;
        }
    }
}
