namespace AdventureWorks.UI.Telerik.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using System.Web.UI;
    using Authorize;
    using Base.Controller; 
    using Service.Person.RestCall;

    public class HomeController : BaseController
    {
        private GetUserInformation _getUserInformation { get; set; }
        private GetUserTitle _getUserTitle { get; set; }

        public HomeController(GetUserInformation getUserInformation, GetUserTitle userTitle)
        {
            _getUserInformation = getUserInformation;
            _getUserTitle = userTitle;
        }

        [CustomAuthorize]
        [OutputCache(Duration = 20, Location = OutputCacheLocation.Client)]
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        
    }
}
