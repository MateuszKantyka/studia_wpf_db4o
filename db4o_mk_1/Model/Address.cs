using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db4o_mk_1.Model
{
    public class Address
    {
        public string Street { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }

        public Address(string street ="", string postCode ="", string city ="")
        {
            Street = street;
            PostCode = postCode;
            City = city;
        }
    }
}
