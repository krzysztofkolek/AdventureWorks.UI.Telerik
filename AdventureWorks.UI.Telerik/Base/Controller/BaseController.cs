namespace AdventureWorks.UI.Telerik.Base.Controller
{
    using System;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.UI;
    using AuthModel;
    using Authorize;
    using Service.Person.RestCall;


    public class BaseController : Controller
    {
        private GetUserInformation _getUserInformation { get; set; }
        private GetUserTitle _getUserTitle { get; set; }

        public BaseController()
        {
            _getUserInformation = new GetUserInformation();
            _getUserTitle = new GetUserTitle();
        }

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

        [CustomAuthorize]
        [OutputCache(Duration = 20, Location = OutputCacheLocation.Client)]
        public async Task<ActionResult> UserName()
        {
            var userName = "";
            var serviceResult = _getUserInformation.SetUrlAndCreateClientInstance(User.Token)
                                              .Result();
            if (serviceResult != null && serviceResult.EmployeeVM != null)
            {
                userName = String.Format("{0} {1}", serviceResult.ContactVM.FirstName, serviceResult.ContactVM.LastName);
            }
            return PartialView("UserName", userName);
        }

        [CustomAuthorize]
        [OutputCache(Duration = 20, Location = OutputCacheLocation.Client)]
        public async Task<ActionResult> Title()
        {
            var userTitle = "";
            var serviceResult = _getUserTitle.SetUrlAndCreateClientInstance(User.Token)
                                              .Result();
            if (serviceResult != null && serviceResult.Title != null)
            {
                userTitle = String.Format("{0}", serviceResult.Title);
            }
            return PartialView("UserTitle", userTitle);
        }
    }
}
