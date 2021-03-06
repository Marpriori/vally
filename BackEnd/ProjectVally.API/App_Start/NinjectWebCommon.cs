using ProjectVally.Application;
using ProjectVally.Application.Interface;
using ProjectVally.Domain.Interfaces.Repository;
using ProjectVally.Domain.Interfaces.Services;
using ProjectVally.Domain.Services;
using ProjectVally.Infra.Data.Repositories;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ProjectVally.API.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(ProjectVally.API.App_Start.NinjectWebCommon), "Stop")]

namespace ProjectVally.API.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

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
            kernel.Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
            kernel.Bind<IUserAppService>().To<UserAppService>();
            kernel.Bind<IAccountAppService>().To<AccountAppService>();
            kernel.Bind<IAccountKindAppService>().To<AccountKindAppService>();
            kernel.Bind<IEntryAppService>().To<EntryAppService>();
            kernel.Bind<IEntryKindAppService>().To<EntryKindAppService>();

            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IAccountService>().To<AccountService>();
            kernel.Bind<IAccountKindService>().To<AccountKindService>();
            kernel.Bind<IEntryService>().To<EntryService>();
            kernel.Bind<IEntryKindService>().To<EntryKindService>();
            
            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IAccountRepository>().To<AccountRepository>();
            kernel.Bind<IAccountKindRepository>().To<AccountKindRepository>();
            kernel.Bind<IEntryRepository>().To<EntryRepository>();
            kernel.Bind<IEntryKindRepository>().To<EntryKindRepository>();
        }        
    }
}
