using AmDemo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmDemo.Service.Services
{
	public interface ICustomerService
	{
		List<Customer> GetCustomers();
	}
}
