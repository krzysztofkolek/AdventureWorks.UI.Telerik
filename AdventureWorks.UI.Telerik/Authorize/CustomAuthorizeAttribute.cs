namespace AdventureWorks.UI.Telerik.Authorize
{
    using System.Web.Mvc;
    using System.Web.Routing;

    internal class CustomAuthorizeAttribute : AuthorizeAttribute
    {

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            // Returns HTTP 401 - see comment in HttpUnauthorizedResult.cs.
            filterContext.Result = new RedirectToRouteResult(
                                       new RouteValueDictionary 
                                   {
                                       { "action", "Login" },
                                       { "controller", "Account" }
                                   });
        }
    }
}
