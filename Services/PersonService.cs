using System;
using System.Collections.Generic;


namespace MiniERP.Services
{
    class PersonService
    {
        /// <summary>
        /// Method for generating person test data
        /// </summary>
        /// <param name="numberOfPerson"></param>
        /// <returns></returns>
        public List<Person> GeneratePersonTestData(int numberOfPerson)
        {
            var personList = new List<Person>();
            Random random = new Random();
            for (int i = 1; i <= numberOfPerson; i++)
            {
                var person = new Person
                {
                    FirstName = "First Name " + i,
                    LastName = "Last Name " + i,
                    DateOfBirth = DateTime.Now.AddYears(random.Next(-50, -10))
                };
                personList.Add(person);
            }
            return personList;
        }
    }
}
