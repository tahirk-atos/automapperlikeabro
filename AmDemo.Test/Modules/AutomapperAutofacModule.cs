using Autofac;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmDemo.Test.Modules
{
	public static class AutomapperAutofacModule
	{

		public static IContainer Configure()
		{
			var builder = new ContainerBuilder();

			RegisterAutomapper(builder);

			var container = builder.Build();

			return container;
		}

		public static IContainer Configure(Profile config)
		{
			var builder = new ContainerBuilder();

			// register any types here
			RegisterAutomapper(builder, config);

			var container = builder.Build();

			return container;
		}
		static void RegisterAutomapper(ContainerBuilder builder)
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

		public static void RegisterAutomapper(ContainerBuilder builder, Profile config)
		{
			builder.Register(m => new MapperConfiguration(cfg =>
				cfg.AddProfile(config)))
				.AsSelf()
				.SingleInstance();

			builder.Register(c => c.Resolve<MapperConfiguration>()
			.CreateMapper(c.Resolve))
			.As<IMapper>()
			.InstancePerLifetimeScope();
		}
	}
}
