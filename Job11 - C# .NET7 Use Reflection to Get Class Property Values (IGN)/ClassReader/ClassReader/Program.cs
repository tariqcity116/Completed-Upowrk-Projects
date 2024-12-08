// See https://aka.ms/new-console-template for more information
using ClassReader;

ClassHelper objHelper = new ClassHelper();
Customer objCustomer = new Customer();
objCustomer.FirstName = "Ali";
objCustomer.LastName = "Umar";
objCustomer.Age = 12;
objCustomer.Addresses  = new List<Address>
    {
        new Address { StreetNumber = "123", StreetName = "Main St" },
        new Address { StreetNumber = "450", StreetName = "Red Rd" }
    };
objCustomer.RelatedCustomers = new List<Customer>
    {
        new Customer { FirstName = "Wanda", LastName = "Jones", Age = 31 }
    };

Console.WriteLine(objHelper.GetPropertiesAndValues(objCustomer));
