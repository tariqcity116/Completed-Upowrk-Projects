using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassReader
{
    
    public class Address
    {
        public string StreetNumber { get; set; } 
        public string StreetName { get; set; } 
    }

    public class Customer
    {
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public int Age { get; set; } 
        public List<Address> Addresses { get; set; } 
        public List<Customer> RelatedCustomers { get; set; }
    }
}
