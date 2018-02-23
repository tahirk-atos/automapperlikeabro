using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using AutoMapper;
using FluentAssertions;
using NUnit.Framework;
using Autofac;
using AmDemo.Test.Modules;
using AmDemo.Test.Profiles;

namespace AmDemo.Test
{
	public class AutomapperProfilesAutofacExampleTests
	{
		private Customer _customer;
		private CustomerViewModel _customerViewModel;
		private ILifetimeScope _scope;
		private IMapper _mapper;

		[SetUp]
		public void SetUp()
		{
			_customer = CustomerModelBuilder();
			_customerViewModel = CustomerViewModelBuilder();

			using (var container = AutomapperAutofacModule.Configure())
			{
				_scope = container.BeginLifetimeScope();

				_mapper = _scope.Resolve<IMapper>();
			}
		}

		[Test]
		public void Given_Valid_Model_MapTo_NewViewModel()
		{
			_customerViewModel = _mapper.Map<CustomerViewModel>(_customer);

			_customerViewModel.Should().NotBeNull().And.BeEquivalentTo(_customer, "");
		}

		private Customer CustomerModelBuilder()
		{
			return new Customer()
			{
				Id = 1,
				Age = 10,
				Firstname = "John",
				Lastname = "Doe",
				Gender = 'M',
				IsActive = true
			};
		}

		private CustomerViewModel CustomerViewModelBuilder()
		{
			return new CustomerViewModel();
		}
	}
}
