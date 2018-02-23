using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AmDemo.Data.Repositories
{
	public class CustomerRepository : BaseRepository<AmDataContext>, ICustomerRepository
	{
		public CustomerRepository(AmDataContext context) : base(context)
		{

		}

		public Customer GetCustomer(int id)
		{
			throw new NotImplementedException();
		}

		public Customer GetCustomer(Expression<Func<Customer, bool>> predicate)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Customer> GetCustomers()
		{
			return Context.Customers;
		}
	}
}
