using AmDemo.Data;
using AmDemo.WinApp.ViewModels;
using AutoMapper;

namespace AmDemo.WinApp.Classes
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
