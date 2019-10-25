using System;

namespace CustomerApp
{
    class Program
    {
        static void Main()
        {
            var customerService = new CustomerService();
            var customerData = customerService.GetCustomerById(1);

            // if statement
            if(customerData == null)
            {
                Console.WriteLine("Müşteri bilgileri bulunamadı.");
            }

            // if-else statement
            if(customerData != null)
            {
                Console.WriteLine($"{customerData.FullName()} - {customerData.EmailAddress}");
            }
            else
            {
                Console.WriteLine("Müşteri bilgileri bulunamadı.");
            }

            // if-else-if statement
            if(customerData != null && string.IsNullOrEmpty(customerData.FirstName))
            {
                Console.WriteLine($"{customerData.FullName()} - {customerData.EmailAddress}");
            }
            else if(customerData != null)
            {
                Console.WriteLine($"{customerData.FullName()} - {customerData.EmailAddress}");
            } 
            else
            {
                Console.WriteLine("Müşteri bilgileri bulunamadı.");
            }

            // Nested if
            if(customerData != null)
            {
                if (string.IsNullOrEmpty(customerData.EmailAddress))
                {
                    Console.WriteLine($"{customerData.FullName()} - Müşteri e-posta bilgisi bulunamadı.");
                }
            }

            // switch statement
            switch (customerData.Id)
            {
                case 1:
                    Console.WriteLine($"{customerData.FullName()} - {customerData.EmailAddress}");
                break;
                case 2:
                    Console.WriteLine($"{customerData.FullName()} - {customerData.PhoneNumber}");
                break;
                default:
                    Console.WriteLine(customerData.FullName());
                break;
            }

            // Nested switch statement
            switch (customerData.LastName)
            {
                case "Skywalker":
                    Console.WriteLine("Last name : Skywalker");

                    switch (customerData.FirstName)
                    {
                        case "Luke":
                            Console.WriteLine("I'm Luke Skywalker. I'm here to rescue you.");
                        break;
                        case "Leia":
                            Console.WriteLine("Help me Obi-Wan Kenobi, you're my only hope.");
                        break;
                        default:
                            Console.WriteLine("I'm your father!");
                        break;
                    }

                break;
                case "Kenobi":
                    Console.WriteLine("That's no moon. It's a space station.");
                break;
                default:
                    Console.WriteLine("May the Force be with you.");
                break;
            }
        }
    }
}