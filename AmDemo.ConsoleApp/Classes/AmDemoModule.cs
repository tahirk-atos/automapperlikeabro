using AmDemo.Data;
using AmDemo.Data.Repositories;
using AmDemo.Service.Services;
using AmDemo.ConsoleApp.Classes;
using Autofac;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmDemo.ConsoleApp.Classes
{
    public class AmDemoModule
    {
        public static IContainer RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<CustomerService>().As<ICustomerService>();
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>();
            builder.RegisterType<ConsoleHelper>().As<IConsoleHelper>();
            builder.RegisterType<AmDataContext>();

            RegisterAutomapper(builder);

            return builder.Build();
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
