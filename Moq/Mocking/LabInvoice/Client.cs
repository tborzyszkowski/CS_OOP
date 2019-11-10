using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabInvoice {
    public class Client {

        private IRepository<Invoice> myInvoices;

        public Client(IRepository<Invoice> repo) {
            myInvoices = repo;
        }

        public Invoice Buy(List<InvoiceItem> list) {
            Invoice iv = new Invoice()
            {
                Id = myInvoices.GetNextID(),
                Customer = "Ja",
                Items = list
            };
            myInvoices.Add(iv);
            return iv;
        }

        public Boolean Return(Invoice iv) {
            if (myInvoices.FindById(iv.Id) == null)
                return false;
            else
            {
                myInvoices.Delete(iv);
                return true;
            }
        }
    }
}
