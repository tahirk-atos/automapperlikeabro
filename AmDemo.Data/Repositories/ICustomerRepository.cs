using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AmDemo.Data.Repositories
{
	public interface ICustomerRepository
	{
		Customer GetCustomer(int id);
		Customer GetCustomer(Expression<Func<Customer, bool>> predicate);
		IEnumerable<Customer> GetCustomers();
	}
}
