[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(AdventureWorks.UI.Telerik.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(AdventureWorks.UI.Telerik.App_Start.NinjectWebCommon), "Stop")]

namespace AdventureWorks.UI.Telerik.App_Start
{
    using System;
    using System.Web;
    using API.Model.Module.User;
    using Configuration;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Service.Base;
    using Service.Person.RestCall;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            //kernel.Bind<BaseConfiguration>().To<BaseConfiguration>().InSingletonScope();
            kernel.Bind<RestData<GetUserInformationModel>>().To<GetUserInformation>().InRequestScope();
            //kernel.Bind<BaseConfiguration>().ToSelf().InSingletonScope();

            kernel.Bind<GetUserTitle>().ToSelf();

        }        
    }
}
