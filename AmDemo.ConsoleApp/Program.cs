using AmDemo.ConsoleApp.Classes;
using System;
using Autofac;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmDemo.ConsoleApp.Classes;

namespace AmDemo.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the AutoMapper Console App Demo");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("\n\n");

            var container = AmDemoModule.RegisterDependencies();

            using (var scope = container.BeginLifetimeScope())
            {
                var _consoleHelper = scope.Resolve<IConsoleHelper>();
                var customer = _consoleHelper.GetCustomer();

                if (customer != null && !string.IsNullOrEmpty(customer.Firstname))
                {
                    Console.WriteLine($"First name: {customer.Firstname}");
                    Console.WriteLine($"Lastname: {customer.Lastname}");
                    Console.WriteLine($"Age: {customer.Age}");
                    Console.WriteLine($"Gender: {customer.Gender}");

                }
            }

            Console.Read();
        }
    }
}
