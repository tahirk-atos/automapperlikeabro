using AmDemo.Data;
using AmDemo.Mvc.Models;
using AutoMapper;

namespace AmDemo.Mvc.Classes
{
	public class CustomerProfile : Profile
	{
		public CustomerProfile()
		{
			CreateMap<CustomerViewModel, Customer>();
			CreateMap<Customer, CustomerViewModel>();
		}
	}
}
