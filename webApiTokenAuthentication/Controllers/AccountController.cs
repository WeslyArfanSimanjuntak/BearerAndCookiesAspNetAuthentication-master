using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace webApiTokenAuthentication.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        
        public string Login(string username, string password)
        {

            if (password == "Admin" && username == "Admin")
            {

                var claimIdentity = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie);

                claimIdentity.AddClaim(new Claim(ClaimTypes.Name, username));
                claimIdentity.AddClaim(new Claim(ClaimTypes.Role, username));

                AuthenticationManager.SignOut("ExternalCookie");

                AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = true }, claimIdentity);


                claimIdentity.AddClaim(claimIdentity.Claims.FirstOrDefault());
                HttpContext.User = AuthenticationManager.AuthenticationResponseGrant.Principal;
                return "success" + User.Identity.Name;
            }
            return "failed";

        }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

    }
}