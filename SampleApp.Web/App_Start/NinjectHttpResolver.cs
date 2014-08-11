using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Dependencies;
using Ninject;
using Ninject.Modules;
using SampleApp.Business;

namespace SampleApp.Web
{
    public class NinjectHttpResolver : IDependencyResolver
    {
        public IKernel Kernel { get; private set; }
        public NinjectHttpResolver(params INinjectModule[] modules)
        {
            Kernel = new StandardKernel(modules);
        }

        public NinjectHttpResolver(Assembly assembly)
        {
            Kernel = new StandardKernel();
            Kernel.Load(assembly);
        }

        public object GetService(Type serviceType)
        {
            return Kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Kernel.GetAll(serviceType);
        }

        public void Dispose()
        {
            //Do Nothing
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }
    }


    // List and Describe Necessary HttpModules
    // This class is optional if you already Have NinjectMvc
    public class NinjectHttpModules
    {
        //Return Lists of Modules in the Application
        public static INinjectModule[] Modules
        {
            get
            {
                return new INinjectModule[] { new MainModule() };
            }
        }

        //Main Module For Application
        public class MainModule : NinjectModule
        {
            public override void Load()
            {
                Kernel.Bind<ISessionProvider>().To<SessionProvider>();
                Kernel.Bind<IUserService>().To<UserService>();
            }
        }
    }


    /// <summary>
    /// Its job is to Register Ninject Modules and Resolve Dependencies
    /// </summary>
    public class NinjectHttpContainer
    {
        private static NinjectHttpResolver _resolver;

        //Register Ninject Modules
        public static void RegisterModules(INinjectModule[] modules)
        {
            _resolver = new NinjectHttpResolver(modules);
            GlobalConfiguration.Configuration.DependencyResolver = _resolver;
        }

        public static void RegisterAssembly()
        {
            _resolver = new NinjectHttpResolver(Assembly.GetExecutingAssembly());
            //This is where the actual hookup to the Web API Pipeline is done.
            GlobalConfiguration.Configuration.DependencyResolver = _resolver;
        }

        //Manually Resolve Dependencies
        public static T Resolve<T>()
        {
            return _resolver.Kernel.Get<T>();
        }
    }
}