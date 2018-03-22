using AmDemo.Data;
using AmDemo.Service.Services;
using AmDemo.WinApp.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmDemo.WinApp.Classes
{
	public class FormHelper : IFormHelper
	{
		private ICustomerService _customerSerice;
		private IMapper _mapper;

		public FormHelper(ICustomerService customerService, IMapper mapper)
		{
			_customerSerice = customerService;
			_mapper = mapper;
		}
		public CustomerViewModel GetCustomer()
		{
			var customer = _customerSerice.GetCustomers().FirstOrDefault();

			return  _mapper.Map<CustomerViewModel>(customer);
		}
	}
}
