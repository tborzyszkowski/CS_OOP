using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabInvoice {
    public class Invoice : IEntity {
        public int Id { get; set; }
        public string Customer { get; set; }
        public List<InvoiceItem> Items { get; set; }

        public bool Equals(IEntity x, IEntity y) {
            return x.Id == y.Id;
        }

        public int GetHashCode(IEntity obj) {
            return obj.Id.GetHashCode();
        }
    }
}
