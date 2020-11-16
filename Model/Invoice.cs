using System.Collections.Generic;

namespace MiniERP.Model
{
    class Invoice
    {

        public Company IssuerCompany { get; set; }
        public Company Customer { get; set; }
        public Person IssuerEmployee { get; set; }
        public List<InvoiceItems> InvoiceItems { get; set; }
        public int InvoiceNumber { get; set; }
        public double Total { get; set; }



    }
}
