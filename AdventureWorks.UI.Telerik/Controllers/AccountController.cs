namespace AdventureWorks.UI.Telerik.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Security;
    using API.Model.Module.User;
    using Authorize;
    using Microsoft.Ajax.Utilities;
    using RestClient;

    public class AccountController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> Login()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(string login, string password, bool createPersistentCookie)
        {
            //var userName = "gustavo0@adventure-works.com";
            //var password = "7e6faf12d9172c49eec309e0b717fc26";
            //var createPersistentCookie = true;
            var token = "";

            var restResult = BaseRestClient<GetUserInformationModel>.Authorizatize("http://localhost:5117/auth", login, password);
            if (restResult != null)
            {
                token = restResult.Token;

                if (!token.IsNullOrWhiteSpace())
                {
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, //version
                        login, // user name
                        DateTime.Now, //creation
                        DateTime.Now.AddMinutes(30), //Expiration (you can set it to 1 month
                        true, //Persistent
                        null); // additional informations
                    var encryptedCookie = FormsAuthentication.Encrypt(authTicket);
                    var authCookie = new HttpCookie("AdventureWorksUser", encryptedCookie);
                    if (createPersistentCookie)
                    {
                        authCookie.Expires = authTicket.Expiration;
                    }
                    authCookie.HttpOnly = true;
                    authCookie.Path = FormsAuthentication.FormsCookiePath;
                    authCookie["UserName"] = login;
                    authCookie["Token"] = token;

                    HttpContext.Response.Cookies.Remove("AdventureWorksUser");
                    HttpContext.Response.SetCookie(authCookie);

                    FormsAuthentication.SetAuthCookie(login, createPersistentCookie);

                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        [CustomAuthorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View();
        }
    }
}
