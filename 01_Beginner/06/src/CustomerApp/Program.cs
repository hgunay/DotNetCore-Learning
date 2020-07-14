using System;

namespace CustomerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region try-catch örneği
            try
            {
                CustomerService customerService = null;
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
            #endregion

            #region try-catch-finally örneği

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

            #endregion

            #region throw örneği

            try
            {
                var customerService = new CustomerService();
                var customerData = customerService.GetCustomerById(0);

                if (customerData == null)
                {
                    throw new NullReferenceException("Hata Kodu : 01 - NullRef hatası oluştu.");
                }
                else
                {
                    Console.WriteLine($"{customerData.FullName()} - {customerData.EmailAddress}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata oluştu! Hata : {ex.Message}");
            }

            #endregion
        }
    }
}