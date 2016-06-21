namespace AdventureWorks.UI.Telerik.Controllers
{
    using System.Web.Mvc;
    using Base.Controller;

    public class PersonController : BaseController
    {
        // GET: Person
        public ActionResult Index()
        {
            return View();
        }
    }
}