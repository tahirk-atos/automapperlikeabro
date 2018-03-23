using AmDemo.Mvc.Models;
using AmDemo.Service.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AmDemo.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private ICustomerService _customerService;
        private IMapper _mapper;

        public HomeController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var customers = _customerService.GetCustomers();

            var customerViewModel = new List<CustomerViewModel>();

            foreach(var c in customers)
            {
                customerViewModel.Add(_mapper.Map<CustomerViewModel>(c));
            }

            return View(customerViewModel);
        }
    }
}