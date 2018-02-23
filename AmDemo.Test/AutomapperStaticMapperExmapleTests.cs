using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using AutoMapper;
using FluentAssertions;
using NUnit.Framework;

namespace AmDemo.Test
{
	/// <summary>
	/// Static mapper configuration example
	/// </summary>
    public class AutomapperStaticMapperExmapleTests
    {
		private Customer _customer;
		private CustomerViewModel _customerViewModel;
		private IMapper _mapper;

		[SetUp]
		public void SetUp()
		{
			_customer = CustomerModelBuilder();
			_customerViewModel = CustomerViewModelBuilder();

			var config = new MapperConfiguration(cfg => cfg.CreateMap<Customer, CustomerViewModel>());
			_mapper = config.CreateMapper();
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
