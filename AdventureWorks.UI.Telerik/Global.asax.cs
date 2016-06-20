namespace AdventureWorks.UI.Telerik
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using Ninject;
    using Service.Person.RestCall;
    using Ninject.Web.Mvc;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            RegisterDependencyResolver();
        }
        
        private void RegisterDependencyResolver()
        {
            var kernel = new StandardKernel();
            kernel.Bind<GetUserTitle>().ToSelf();
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
