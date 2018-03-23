using AmDemo.Data;
using AmDemo.Data.Repositories;
using AmDemo.Service.Services;
using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AmDemo.Mvc.Classes
{
    public static class Module
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<CustomerService>().As<ICustomerService>();
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>();
            builder.RegisterType<AmDataContext>();

            RegisterAutomapper(builder);

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void RegisterAutomapper(ContainerBuilder builder)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            builder.RegisterAssemblyTypes(assemblies)
                .Where(t => typeof(Profile).IsAssignableFrom(t) && !t.IsAbstract && t.IsPublic)
                .As<Profile>();

            builder.Register(m => new MapperConfiguration(cfg =>
            {
                foreach (var profile in m.Resolve<IEnumerable<Profile>>())
                {
                    cfg.AddProfile(profile);
                }
            })).AsSelf().SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>()
            .CreateMapper(c.Resolve))
            .As<IMapper>()
            .InstancePerLifetimeScope();
        }
    }
}
