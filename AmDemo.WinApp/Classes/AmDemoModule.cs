using AmDemo.Data;
using AmDemo.Data.Repositories;
using AmDemo.Service.Services;
using Autofac;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmDemo.WinApp.Classes
{
	public class AmDemoModule
	{
		public static IContainer RegisterDependencies()
		{
			var builder = new ContainerBuilder();

			builder.RegisterType<CustomerService>().As<ICustomerService>();
			builder.RegisterType<CustomerRepository>().As<ICustomerRepository>();
			builder.RegisterType<FormHelper>().As<IFormHelper>();
			builder.RegisterType<AmDataContext>();
			builder.RegisterType<Form1>().AsSelf();

			RegisterAutomapper(builder);

			var container = builder.Build();
			return container;
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
