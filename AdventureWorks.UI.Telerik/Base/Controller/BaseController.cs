namespace AdventureWorks.UI.Telerik.Base.Controller
{
    using System.Web;
    using System.Web.Mvc;
    using AuthModel;

    public class BaseController : Controller
    {
        protected ApplicationUser User
        {
            get
            {
                ApplicationUser newUser = new ApplicationUser();
                HttpCookie user = HttpContext.Request.Cookies.Get("AdventureWorksUser");
                if (user != null)
                {
                    newUser.Login = user["UserName"];
                    newUser.Token = user["Token"];
                }
                return newUser;
            }
        }
    }
}
