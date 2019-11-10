using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabInvoice
{
	public class InvoiceItem : IEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }
		public double Tax { get; set; }

		public bool Equals(IEntity x, IEntity y)
		{
			throw new NotImplementedException();
		}

		public int GetHashCode(IEntity obj)
		{
			throw new NotImplementedException();
		}
	}
}
