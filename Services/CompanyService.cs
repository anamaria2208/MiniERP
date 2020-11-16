using MiniERP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniERP.Services
{
    class CompanyService
    {

        /// <summary>
        /// Generate hardcoded company data
        /// </summary>
        /// <returns>
        /// Company object
        /// </returns>
        public Company GenerateCompanyData()
        {
            Company company = new Company
            {
                Address = new Address
                {
                    Street = "Random street",
                    City = "City X",
                    Zip = 10000
                },
                CompanyName = "MySolutions d.o.o.",
                VAT = "HR01234567896",
                Employees = new List<Person> { GetEmployee() }
            };
                 return company;
        }

        /// <summary>
        /// Generate hardcoded employee
        /// </summary>
        /// <returns>
        /// One employee object
        /// </returns>
        public Person GetEmployee()
        {
            var employee = new Person
            {
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = DateTime.Parse("22-07-1985")
            };
            return employee;
        }
              


        /// <summary>
        /// Generate test customer list
        /// </summary>
        /// <param name="numberOfCustomers">
        /// Number of test customer data
        /// </param>
        /// <returns>
        /// List of random customers
        /// </returns>
        public List<Company> GenerateTestCustomer(int numberOfCustomers)
        {
            var customerList = new List<Company>();

            for (int i = 1; i <= numberOfCustomers; i++)
            {
                var customer = new Company
                {
                    CompanyName = "Customer " + i,
                    VAT = "0123456789" + i,
                    Id = i,
                    Address = new Address
                    {
                        City = "City Y" + i,
                        Zip = 1000 * i,
                        Street = "Street " + i
                    }

                };
                customerList.Add(customer);
            }
            return customerList;
        }
    }
}
