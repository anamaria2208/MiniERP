using MiniERP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MiniERP.Services
{
    class InvoiceService
    {

        /// <summary>
        /// Method for generate new invoice
        /// </summary>
        /// <param name="companyIssuer">
        /// Company that issues invoice
        /// </param>
        /// <param name="responsiblePerson">
        /// Employee that issues invoice, responsible person
        /// </param>
        /// <param name="invoiceItems">
        /// Invoice items
        /// </param>
        /// <param name="Customer">
        /// Customer - company that buys products
        /// </param>
        /// <returns>
        /// Populated invoice object
        /// </returns>
        public Invoice GenerateInvoice(Company companyIssuer, Person responsiblePerson, List<InvoiceItems> invoiceItems, Company Customer)
        {
            Invoice invoice = new Invoice();
            Random random = new Random();
            invoice.InvoiceNumber = random.Next(1, 5000);
            invoice.IssuerCompany = companyIssuer;
            invoice.IssuerEmployee = responsiblePerson;
            invoice.Customer = Customer;
            invoice.InvoiceItems = invoiceItems;
            invoice.Total = invoiceItems.Select(x => x.Price).FirstOrDefault();
            return invoice;
        }


        /// <summary>
        /// User picks invoice line for invoicing
        /// </summary>
        /// <param name="input">
        /// List of generated test invoice data in InvoiceLineService class
        /// </param>
        /// <returns>
        /// List of invoice lines
        /// </returns>
        public List<InvoiceItems> ListOfItemsForInvocing(List<InvoiceItems> input)
        {
            var itemList = new List<InvoiceItems>();
            bool end = false;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*************CHOOSE ITEM*************");
            Console.ResetColor();
            foreach (var item in input)
            {
                Console.WriteLine("Id: {0}  |  Name: {1}", item.Id, item.ItemName);
            }

            while (!end)
            {
                itemList.Add(GetInvoiceItem(input));
                Console.WriteLine("---------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Done? Write 'YES' to quit or 'NO' to continue: ");
                Console.ResetColor();
                if (Console.ReadLine().ToLower() == "yes")
                {
                    end = true;
                }
            }
            return itemList;
        }

        private static InvoiceItems GetInvoiceItem(List<InvoiceItems> input)
        {
            Console.Write("Choose item ID: ");
            int id = int.Parse(Console.ReadLine());
            InvoiceItems choosenItem = input.FirstOrDefault(x => x.Id == id);
            return choosenItem;
        }

        /// <summary>
        /// Method for asking user to choose customer
        /// </summary>
        /// <param name="customers">
        /// List of test customer data
        /// </param>
        /// <returns>
        /// Customer object
        /// </returns>
        public Company ChooseCustomer(List<Company> customers)
        {
            Company customer = new Company();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*************CHOOSE CUSTOMER*************");
            Console.ResetColor();
            foreach (var item in customers)
            {
                Console.WriteLine("ID: {0}  |  Name: {1}", item.Id, item.CompanyName);
            }
            Console.Write("Choose customer ID: ");
            int id = int.Parse(Console.ReadLine());
            customer = customers.FirstOrDefault(x => x.Id == id);
            return customer;
        }



        public void InvoicePrint(Invoice invoice)
        {
            Console.WriteLine();
            Console.WriteLine("*************************************INVOICE PRINT*************************************");
            Console.WriteLine("Invoice number: {0}", invoice.InvoiceNumber);
            Console.WriteLine("Customer: {0}", invoice.Customer.CompanyName);
            Console.WriteLine("Issuer Company: {0}", invoice.IssuerCompany.CompanyName);
            Console.WriteLine("Responsible person: {0} {1}", invoice.IssuerEmployee.FirstName, invoice.IssuerEmployee.LastName);
            Console.WriteLine("Invoice total: {0} EUR", invoice.Total);
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("Items: ");
            foreach (var item in invoice.InvoiceItems)
            {
                Console.WriteLine("Item name: {0}, ID: {1}", item.ItemName, item.Id);
            }
            Console.WriteLine("-------------------------------------------------------------------------");
        }
    }
}
