using AmDemo.Data;
using AmDemo.Models;
using AutoMapper;

namespace AmDemo.ConsoleApp.Classes
{
	public class CustomerProfile : Profile
	{
		public CustomerProfile()
		{
			CreateMap<CustomerModel, Customer>();
			CreateMap<Customer, CustomerModel>();
		}
	}
}
