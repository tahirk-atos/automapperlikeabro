using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmDemo.Test.Profiles
{
	class CustomerProfile : Profile
	{
		public CustomerProfile()
		{
			CreateMap<CustomerViewModel, Customer>();
			CreateMap<Customer, CustomerViewModel>();
		}
	}
}
