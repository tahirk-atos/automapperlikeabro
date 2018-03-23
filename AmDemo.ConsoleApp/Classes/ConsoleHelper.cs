using AmDemo.Data;
using AmDemo.Service.Services;
using AmDemo.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmDemo.ConsoleApp.Classes;

namespace AmDemo.ConsoleApp.Classes
{
    public class ConsoleHelper : IConsoleHelper
    {
        private ICustomerService _customerSerice;
        private IMapper _mapper;

        public ConsoleHelper(ICustomerService customerService, IMapper mapper)
        {
            _customerSerice = customerService;
            _mapper = mapper;
        }
        public CustomerModel GetCustomer()
        {
            var customer = _customerSerice.GetCustomers().FirstOrDefault();

            return _mapper.Map<CustomerModel>(customer);
        }
    }
}
