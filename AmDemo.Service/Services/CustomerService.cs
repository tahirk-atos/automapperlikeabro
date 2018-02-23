using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmDemo.Data;
using AmDemo.Data.Repositories;

namespace AmDemo.Service.Services
{
	public class CustomerService : ICustomerService
	{
		private readonly ICustomerRepository _customerRepository;

		public CustomerService(ICustomerRepository customerRepository)
		{
			_customerRepository = customerRepository;
		}

		public List<Customer> GetCustomers()
		{
			return _customerRepository.GetCustomers().ToList();
		}
	}
}
