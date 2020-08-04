using System;

namespace CustomerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Müşteri Bilgilerini Giriniz");
                Console.WriteLine("---------------------------");

                Console.Write("Müşteri Adı      : ");
                var firstName = Console.ReadLine();

                Console.Write("Müşteri Soyadı   : ");
                var lastName = Console.ReadLine();

                Console.Write("Telefon No       : ");
                var phoneNumber = Console.ReadLine();

                Console.Write("E-posta Adresi   : ");
                var email = Console.ReadLine();

                var customerService = new CustomerService();
                if (customerService != null)
                {
                    var customerId = customerService.AddCustomer(firstName, lastName, phoneNumber, email);

                    if (customerId > 0)
                    {
                        Console.WriteLine($"Müşteri No       : {customerId}");

                        Console.WriteLine();

                        Console.WriteLine("Adres Bilgilerini Giriniz");
                        Console.WriteLine("---------------------------");

                        Console.Write("Adres    : ");
                        var address = Console.ReadLine();

                        Console.Write("İl       : ");
                        var city = Console.ReadLine();

                        Console.Write("İlçe     : ");
                        var county = Console.ReadLine();

                        Console.Write("Semt     : ");
                        var district = Console.ReadLine();

                        var customerAddressId = customerService.AddCustomerAddress(customerId, address, city, county, district);

                        if (customerAddressId > 0)
                        {
                            var customer = customerService.GetCustomerById(customerId);
                            var customerAddress = customerService.GetCustomerAddressById(customerId);

                            Console.WriteLine();

                            Console.WriteLine("Müşteri Bilgileri");
                            Console.WriteLine("-----------------");
                            Console.WriteLine($"Id : {customer.Id} | Adı - Soyadı : {customer.CustomerFullName} | Telefon No : {customer.PhoneNumber} | E-Posta : {customer.EmailAddress}");
                            Console.WriteLine("-----------------");

                            Console.WriteLine();

                            Console.WriteLine("Adres Bilgileri");
                            Console.WriteLine("---------------");
                            Console.WriteLine($"Id : {customerAddress.Id} | Müşteri Id : {customerAddress.CustomerId} | Adres : {customerAddress.Address} | İl : {customerAddress.City} | İlçe : {customerAddress.County} | Semt : {customerAddress.District}");
                            Console.WriteLine("---------------");
                            
                            Console.WriteLine();

                            Console.WriteLine("Polymorphisim ile gelen bilgiler...");
                            Console.WriteLine("-----------------------------------");
                            customerService.GetCustomerInfo();
                            Console.WriteLine();
                            customerService.GetCustomerAddressInfo();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Hata! Müşteri no alınamadı.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine($"Hata oluştu! Hata : {ex}");
            }
            finally
            {
                Console.WriteLine();
                Console.WriteLine("İşlem tamamlandı.");
            }
        }
    }
}