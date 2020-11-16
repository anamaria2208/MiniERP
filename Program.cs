using Newtonsoft.Json;
using MiniERP.Model;
using MiniERP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Design;

namespace MiniERP
{
    class Program
    {
        static void Main(string[] args)
        {
            CompanyService cs;
            InvoiceLineService ils;
            InvoiceService iss;
            InstantiateServices(out cs, out ils, out iss);
            List<InvoiceItems> itemList = GetNumberOfTestItemsFromUser(ils, iss);

            Console.Write("Enter number to generate customer test data: ");
            int numberCustomer = int.Parse(Console.ReadLine());
            Company customer = iss.ChooseCustomer(cs.GenerateTestCustomer(numberCustomer));

            Invoice invoice = iss.GenerateInvoice(cs.GenerateCompanyData(), cs.GetEmployee(), itemList, cs.GenerateCompanyData());
            iss.InvoicePrint(invoice);

            //fs.JsonInputToFile(invoice, "racun.txt", "logs");





        }

        private static void InstantiateServices(out CompanyService cs, out InvoiceLineService ils, out InvoiceService iss)
        {
            FileService fs = new FileService();
            cs = new CompanyService();
            ils = new InvoiceLineService();
            iss = new InvoiceService();
            PersonService ps = new PersonService();
        }

        private static List<InvoiceItems> GetNumberOfTestItemsFromUser(InvoiceLineService ils, InvoiceService iss)
        {
            bool input = false;
            int numberOfItems = 0;

            while (!input)
            {
                Console.Write("Enter number to generate invoice line test data: ");
                input = int.TryParse(Console.ReadLine(), out numberOfItems);
                if (!input)
                {
                    Console.WriteLine("Invalid input! Try again!");
                }
                else
                {
                    input = true;
                }
            }
            List<InvoiceItems> itemList = iss.ListOfItemsForInvocing(ils.GenerateItemTestData(numberOfItems));
            return itemList;
        }
    }
}
