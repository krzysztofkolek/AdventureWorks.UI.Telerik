namespace AdventureWorks.UI.Telerik.Controllers
{
    using System.Web.Mvc;
    using Authorize;
    using Base.Controller;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Models.ControllerViewModel.HumanResources;
    using Service.HumanResources.RestCall;

    public class HumanResourcesController : BaseController
    {
        private GetEmployees _getEmployees { get; set; }

        public HumanResourcesController(GetEmployees getEmployees)
        {
            _getEmployees = getEmployees;
        }

        [HttpGet]
        [CustomAuthorize]
        public ActionResult GetEmployees()
        {
            //var data = _getEmployees.SetPage(1).SetUrlAndCreateClientInstance(User.Token).Result();
            return View();
        } 

        public ActionResult GetEmployeesRead([DataSourceRequest] DataSourceRequest request)
        {
            return Json(_getEmployees.SetPage(1).SetUrlAndCreateClientInstance(User.Token).Result().Employees.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult GetEmployeesCreate([DataSourceRequest] DataSourceRequest request, GetEmployeesItemModel product)
        {
            //if (product != null && ModelState.IsValid)
            //{
            //    productService.Create(product);
            //}

            //return Json(new[] { product }.ToDataSourceResult(request, ModelState));
            return null;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult GetEmployeesUpdate([DataSourceRequest] DataSourceRequest request, GetEmployeesItemModel product)
        {
            //if (product != null && ModelState.IsValid)
            //{
            //    productService.Update(product);
            //}

            //return Json(new[] { product }.ToDataSourceResult(request, ModelState));
            return null;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult GetEmployeesDestroy([DataSourceRequest] DataSourceRequest request, GetEmployeesItemModel product)
        {
            //if (product != null)
            //{
            //    productService.Destroy(product);
            //}

            //return Json(new[] { product }.ToDataSourceResult(request, ModelState)); 
            return null;
        }

    }
}