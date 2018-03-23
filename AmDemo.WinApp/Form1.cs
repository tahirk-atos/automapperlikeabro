using AmDemo.WinApp.Classes;
using Autofac;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmDemo.WinApp
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void btnGo_Click(object sender, EventArgs e)
		{
			var container = AmDemoModule.RegisterDependencies();

			using (var scope = container.BeginLifetimeScope())
			{
				var _formHelper = scope.Resolve<IFormHelper>();
				var customer = _formHelper.GetCustomer();

				if (customer != null && !string.IsNullOrEmpty(customer.Firstname))
				{
					tbFirstname.Text = customer.Firstname;
					tbLastname.Text = customer.Lastname;
					tbAge.Text = customer.Age.ToString();
					tbGender.Text = customer.Gender.ToString();
				}
			}
		}
	}
}
