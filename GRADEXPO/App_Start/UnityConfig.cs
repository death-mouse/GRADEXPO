using GRADEXPO.Repository;
using GRADEXPO.Services;
using System;

using Unity;

namespace GRADEXPO
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();
            container.RegisterType<IUsersRepository, UsersRepository>();
            container.RegisterType<IUsersService, UsersService>();
            container.RegisterType<IExposRepository, ExposRepository>();
            container.RegisterType<IExposService, ExposService>();
            container.RegisterType<IStandsService, StandsService>();
            container.RegisterType<IStandsRepository, StandsRepository>();
            container.RegisterType<IFileRepository, FileRepository>();
            container.RegisterType<IFileService, FileService>();

            container.RegisterType<IVisitRepository, VisitRepository>();
            container.RegisterType<IVisitService, VisitService>();

            container.RegisterType<IExpoFilesRepository, ExpoFilesRepository>();
            container.RegisterType<IExpoFilesService, ExpoFilesService>();
            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
        }
    }
}