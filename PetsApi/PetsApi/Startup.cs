using System;
using Microsoft.Owin;
using Owin;
//using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using System.Threading.Tasks;
using PetsDatabaseDLL;
using System.Security.Claims;
using Microsoft.AspNet.Identity.EntityFramework;
using PetsApi.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Collections.Generic;
using Microsoft.Owin.Cors;

[assembly: OwinStartup(typeof(PetsApi.Startup))]

namespace PetsApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions()
            {
                TokenEndpointPath = new PathString("/token"),
                AllowInsecureHttp = true,
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(3),
                Provider = new MyProvider()
            });
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
    public class MyProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        //Login(username,password
        //token
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            if (context.UserName == null || context.Password == null)
                context.SetError("User Name or Password cant be Empty");
            else
            {
                //call find from AuthBl
                //AuthBusinessLayer authbl = new AuthBusinessLayer();
                //IdentityUser users = authbl.Find(context.UserName, context.Password);
                var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
                var manager = new UserManager<ApplicationUser>(userStore);
                var users = await manager.FindAsync(context.UserName, context.Password);
                if (users == null)
                {
                    context.SetError("User Name or Password cant be Empty");

                }
                else
                {
                    
                    if (users != null)
                    {
                        var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                        identity.AddClaim(new Claim("Username", users.UserName));
                        identity.AddClaim(new Claim("Email", users.Email));
                        identity.AddClaim(new Claim("FirstName", users.FirstName));
                        identity.AddClaim(new Claim("LastName", users.LastName));
                        identity.AddClaim(new Claim("LoggedOn", DateTime.Now.ToString()));
                        identity.AddClaim(new Claim("ID", users.Id));

                        var userRoles = manager.GetRoles(users.Id);
                        foreach (string roleName in userRoles)
                        {
                            identity.AddClaim(new Claim(ClaimTypes.Role, roleName));
                        }
                        var additionalData = new AuthenticationProperties(new Dictionary<string, string>{
                    {
                "role", Newtonsoft.Json.JsonConvert.SerializeObject(userRoles)
                    }
                });
                        var token = new AuthenticationTicket(identity, additionalData);
                        context.Validated(token);
                        //context.Validated(identity);
                    }
                    else
                        return;

                }
            }
        }
        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }
    }
}

