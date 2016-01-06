using HomeMovieCollection.Core;
using HomeMovieCollection.Core.Objects;
using HomeMovieCollection.Providers;
using Ninject;
using Ninject.Web.Common;
using System.Web.Mvc;
using System.Web.Routing;

namespace HomeMovieCollection
{
        public class MvcApplication : NinjectHttpApplication
        {
            protected override IKernel CreateKernel()
            {
                var kernel = new StandardKernel();

                kernel.Load(new RespositoryModule());
                kernel.Bind<IMovieCollectionRespository>().To<MovieCollectionRepository>();
                kernel.Bind<IAuthProvider>().To<AuthProvider>();

                return kernel;
            }

            protected override void OnApplicationStarted()
            {
                ModelBinders.Binders.Add(typeof(Movie), new MovieModelBinder(Kernel));
                RouteConfig.RegisterRoutes(RouteTable.Routes);
                base.OnApplicationStarted();
            }
        }

}
