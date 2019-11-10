using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabInvoice
{
	public interface IEntity : IEqualityComparer<IEntity>
	{
		int Id { get; set; }
	}
}
