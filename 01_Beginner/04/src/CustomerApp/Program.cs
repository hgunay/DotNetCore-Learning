using System;

namespace CustomerApp
{
    class Program
    {
        static void Main()
        {
            // Code 1
            var customer = new Customer();
            
            customer.FirstName = "Luke";
            customer.LastName = "Skywalker";

            var customerFullName = customer.FullName();

            Console.WriteLine($"{customerFullName}");

            // Code 2
            var customerService = new CustomerService();
            var customerData = customerService.GetCustomerById(1);

            if(customerData != null)
            {
                Console.WriteLine($"{customerData.FullName()} - {customerData.EmailAddress}");
            }
            else
            {
                Console.WriteLine("Müşteri bilgileri bulunamadı.");
            }            
        }
    }
}