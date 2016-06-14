namespace AdventureWorks.UI.Telerik.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Authorize;

    public class AccountController : Controller
    {

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }


        [CustomAuthorize]
        public ActionResult Logout()
        {
            return View();
        }
    }
}
