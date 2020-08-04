using System;

namespace CustomerApp
{
    /// <summary>
    /// Customer Class
    /// </summary>
    public class Customer : BaseCustomer
    {
        /// <summary>
        /// Müşteri Adı 
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Müşteri Soyadı
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Müşteri Adı Soyadı
        /// </summary>
        public string CustomerFullName => $"{FirstName} {LastName}";

        /// <summary>
        /// Müşteri Telefon No
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Müşteri E-posta Adresi
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Customer() { }

        public override void GetCustomerInfo()
        {
            Console.WriteLine("Müşteri Bilgileri");
            Console.WriteLine("-----------------");
            base.GetCustomerInfo();
            Console.WriteLine($"Adı - Soyadı : {CustomerFullName} | Telefon No : {PhoneNumber} | E-Posta : {EmailAddress}");
            Console.WriteLine("-----------------");
        }
    }
}