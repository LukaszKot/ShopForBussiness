using Autofac;
using Autofac.Integration.Web;
using ShopForBussiness.Dto;
using ShopForBussiness.MySQL;
using ShopForBussiness.Repositories;
using ShopForBussiness.Services;
using System;
using System.Web.UI;

namespace ShopForBussiness
{
    public class Global : System.Web.HttpApplication, IContainerProviderAccessor
    {
        static IContainerProvider _containerProvider;

        public IContainerProvider ContainerProvider { get { return _containerProvider; } }

        protected void Application_Start(object sender, EventArgs e)
        {
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery",
                new ScriptResourceDefinition
                {
                    Path = "~/scripts/jquery.js",
                    DebugPath = "~/scripts/jquery.js",
                    CdnPath = "https://code.jquery.com/jquery-3.4.1.min.js",
                    CdnDebugPath = "https://code.jquery.com/jquery-3.4.1.min.js"
                });
            ScriptManager.ScriptResourceMapping.AddDefinition("bootstrap",
                new ScriptResourceDefinition
                {
                    Path = "~/scripts/bootstrap.js",
                    DebugPath = "~/scripts/bootstrap.js",
                    CdnPath = "https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js",
                    CdnDebugPath = "https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"
                });


            var builder = new ContainerBuilder();
            builder.RegisterInstance(new ShopForBusinessContext()).SingleInstance();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<AddressRepository>().As<IAddressRepository>().InstancePerLifetimeScope();
            builder.RegisterType<AddressService>().As<IAddressService>().InstancePerLifetimeScope();
            builder.RegisterType<ProductRepository>().As<IProductRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerLifetimeScope();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>().InstancePerLifetimeScope();
            /*builder.RegisterType<OrderService>().As<IOrderService>().InstancePerLifetimeScope();*/
            builder.RegisterType<Encrypter>().As<IEncrypter>().InstancePerLifetimeScope();
            builder.RegisterInstance(AutoMapperConfig.Initilize()).SingleInstance();
            _containerProvider = new ContainerProvider(builder.Build());
        }
    }
}