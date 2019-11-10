using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabInvoice
{
	class InvoiceRepository : IRepository<Invoice>
	{
		private List<Invoice> dataSource = new List<Invoice>();
		public IEnumerable<Invoice> List => dataSource;

		public void Add(Invoice entity)
		{
			if (FindById(entity.Id) == null)
				dataSource.Add(entity);
		}

		public void Delete(Invoice entity)
		{
			dataSource.Remove(entity);
		}

		public Invoice FindById(int Id)
		{
			return dataSource.Find(x => x.Id == Id);
		}

		public void Update(Invoice entity)
		{
			if (FindById(entity.Id) != null)
				Delete(entity);
			else
				throw new ArgumentException();
			Add(entity);
		}
		public int GetNextID()
		{
			return dataSource[dataSource.Count - 1].Id + 1;
		}
	}
}
