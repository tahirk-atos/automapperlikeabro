using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmDemo.Models
{
	public class CustomerModel
	{
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public int Age { get; set; }
		public char Gender { get; set; }
		public bool IsActive { get; set; }
	}
}
