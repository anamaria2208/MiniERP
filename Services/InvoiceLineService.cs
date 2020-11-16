using MiniERP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniERP.Services
{
    class InvoiceLineService
    {
        /// <summary>
        /// Generate Item list test data
        /// </summary>
        /// <param name="numberofItems">
        /// Number of generated items
        /// </param>
        /// <returns>
        /// Item list
        /// </returns>
        public List<InvoiceItems> GenerateItemTestData(int numberofItems)
        {
            List<InvoiceItems> items = new List<InvoiceItems>();
            for (int i = 1; i <= numberofItems; i++)
            {
                var invoiceItem = new InvoiceItems
                {
                    Price = 10 * i,
                    Id = i,
                    ItemName = "Item " + i
                };
                items.Add(invoiceItem);
            }
            return items;
        }
    }
}
