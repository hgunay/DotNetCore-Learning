using System;

namespace CustomerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var customerService = new CustomerService();
                var customerData = customerService.GetCustomerById(1);

                if (customerData == null)
                {
                    Console.WriteLine("Müşteri bilgileri bulunamadı.");
                }
                else
                {
                    Console.WriteLine($"{customerData.FullName()} - {customerData.EmailAddress}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata oluştu! Hata : {ex}");
            }
            finally
            {
                Console.WriteLine("İşlem tamamlandı.");
            }
        }
    }
}