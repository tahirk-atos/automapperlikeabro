using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmDemo.Data.Repositories
{
	public class BaseRepository<T> where T : AmDataContext
	{
		public T Context { get; set; }

		public BaseRepository(T context)
		{
			Context = context;
		}

		public virtual void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public virtual void Dispose(bool disposing)
		{
			if (disposing && Context != null)
			{
				Context.Dispose();
				Context = null;
			}
		}
	}
}
