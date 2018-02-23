namespace AmDemo.Data
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class AmDataContext : DbContext
	{
		public AmDataContext()
			: base("name=Database1")
		{
		}

		public virtual DbSet<Customer> Customers { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Customer>()
				.Property(e => e.Gender)
				.IsFixedLength()
				.IsUnicode(false);
		}
	}
}
