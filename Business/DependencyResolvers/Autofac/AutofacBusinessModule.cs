using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
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

            builder.RegisterType<UserManager>().As<IUserManager>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly)
                .AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions { Selector = new AspectInterceptorSelector() })
                .SingleInstance();

        }
    }
}
