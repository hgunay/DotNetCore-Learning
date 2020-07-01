using System;

namespace CustomerApp
{
    class Program
    {
        static void Main()
        {
            var customerService = new CustomerService();
            var customerData = customerService.GetCustomerById(1);

            #region Statements
                
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

            #endregion

            #region Loops
            
            // for loop
            for (var i = 1; i <= 3; i++)
            {
                Console.WriteLine($"for : {i}. {customerData.FullName()}");
            }

            // while loop
            var j = 1;
            while (j <= 3)
            {
                Console.WriteLine($"while : {j}. {customerData.FullName()}");
                j++;
            }

            // do...while loop
            var x = 1;
            do
            {
                Console.WriteLine($"do-while : {x}. {customerData.FullName()}");
                x++;
            } while (x <= 3);

            // foreach loop
            var list = new int[]{ 1, 2, 3 };
            foreach (var item in list)
            {
                Console.WriteLine($"foreach : {item}. {customerData.FullName()}");
            }            

            #endregion
			
			#region Jumping Statements
            
            // break
            var movieTypeList = new string[]{ "dram", "action", "sci-fi", "romance" };
            foreach (var item in movieTypeList)
            {
                if(item == "sci-fi")
                {
                    Console.WriteLine($"Movie Type : {item}");
                    break;
                }

                Console.WriteLine($"Movie Type : {item}");
            }

            // continue
            movieTypeList = new string[]{ "dram", "action", "romance", "sci-fi" };
            foreach (var item in movieTypeList)
            {
                if(item == "romance")
                {
                    continue;
                }

                Console.WriteLine($"Movie Type : {item}");
            }

            // goto
            movieTypeList = new string[]{ "dram", "action", "romance", "sci-fi" };
            foreach (var item in movieTypeList)
            {
                switch (item)
                {
                    case "dram":
                        goto default;
                    case "action":
                        goto default;
                    case "romance":
                        goto default;
                    case "sci-fi":
                        Console.WriteLine($"Movie type is Sci-Fi");
                        break;
                    default:
                        Console.WriteLine($"Movie type is...");
                        break;
                }
            }

            #endregion            
        }
    }
}