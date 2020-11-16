using MiniERP.Model;
using System;


namespace MiniERP
{
    class Person
    {
        public string FirstName { get; set; }
        public string LastName  {get; set; }
        public DateTime DateOfBirth { get; set; }
        public Address Address { get; set; }

    }
}
