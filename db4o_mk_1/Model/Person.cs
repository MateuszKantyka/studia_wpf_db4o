using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db4o_mk_1.Model
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public List<Phone> Phones { get; set; }

        public Person(string firstName, string lastName,Address address = null,List<Phone> phones = null)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;

            if (phones == null)
            {
                Phones = new List<Phone>();
            }
            else
            {
                Phones = phones;
            }
        }
    }
}
