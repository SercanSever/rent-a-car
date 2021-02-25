
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Integration.Mvc;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);




            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<CarManager>().As<ICarManager>();
            builder.RegisterType<EfCarDal>().As<ICarDal>();

            builder.RegisterType<BrandManager>().As<IBrandManager>();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>();

            builder.RegisterType<ColorManager>().As<IColorManager>();
            builder.RegisterType<EfColorDal>().As<IColorDal>();

            builder.RegisterType<CustomerManager>().As<ICustomerManager>();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>();

            builder.RegisterType<RentalManager>().As<IRentalManager>();
            builder.RegisterType<EfRentalDal>().As<IRentalDal>();

            builder.RegisterType<CarImageManager>().As<ICarImageManager>();
            builder.RegisterType<EfCarImageDal>().As<ICarImageDal>();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}
