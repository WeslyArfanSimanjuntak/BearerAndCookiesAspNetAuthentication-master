using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.DirectoryServices.AccountManagement;
using System.Web;

namespace webApiTokenAuthentication
{
    public class MyAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated(); // 
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            bool isValid = false;
            //UserPrincipal userPrincipal = null;
            //PrincipalContext pc = new PrincipalContext(ContextType.Domain, "INDOSURYALIFE");
            //using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "INDOSURYALIFE"))
            //{
            // validate the credentials
            if(context.UserName == "AdminToken" && context.Password == "AdminToken")
            {
                isValid = true;

            }
            //isValid = pc.ValidateCredentials(context.UserName, context.Password);
            //    userPrincipal = UserPrincipal.FindByIdentity(pc, IdentityType.SamAccountName, context.UserName);
            ////}
            if (isValid)
            {
                identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
                context.Validated(identity);
            }
            else
            {
                context.SetError("invalid_grant", "Provided username and password is incorrect");
                return;
            }

            //if (context.UserName == "admin" && context.Password == "admin")
            //{
            //    identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
            //    identity.AddClaim(new Claim("username", "admin"));
            //    identity.AddClaim(new Claim(ClaimTypes.Name, "Sourav Mondal"));
            //    context.Validated(identity);
            //}
            //else if (context.UserName == "user" && context.Password == "user")
            //{
            //    identity.AddClaim(new Claim(ClaimTypes.Role, "user"));
            //    identity.AddClaim(new Claim(ClaimTypes.Role, "user1"));
            //    identity.AddClaim(new Claim(ClaimTypes.Role, "user2"));
            //    identity.AddClaim(new Claim(ClaimTypes.Role, "user3"));
            //    identity.AddClaim(new Claim(ClaimTypes.Role, "user4"));
            //    identity.AddClaim(new Claim(ClaimTypes.Role, "user5"));
            //    identity.AddClaim(new Claim(ClaimTypes.Role, "user6"));
            //    identity.AddClaim(new Claim(ClaimTypes.Role, "user7"));
            //    identity.AddClaim(new Claim(ClaimTypes.Role, "user8"));
            //    identity.AddClaim(new Claim(ClaimTypes.Role, "user9"));
            //    identity.AddClaim(new Claim(ClaimTypes.Role, "user10"));
            //    identity.AddClaim(new Claim(ClaimTypes.Role, "user11"));
            //    identity.AddClaim(new Claim(ClaimTypes.Role, "user12"));
            //    identity.AddClaim(new Claim("username", "user"));
            //    identity.AddClaim(new Claim(ClaimTypes.Name, "Suresh Sha"));
            //    context.Validated(identity);
            //}
            //else
            //{
            //    context.SetError("invalid_grant", "Provided username and password is incorrect");
            //    return;
            //}
        }
    }
}