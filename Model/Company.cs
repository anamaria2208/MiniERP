using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MiniERP.Model
{
    class Company
    {

        public string CompanyName { get; set; }
        public int Id { get; set; }
        public string VAT { get; set; }
        public Address Address { get; set; }
        public List<Person> Employees { get; set; }

    }
}
