using System;

namespace CustomerApp
{
    /// <summary>
    /// Customer Address Class
    /// </summary>
    public class CustomerAddress : BaseCustomer
    {
        /// <summary>
        /// Müşteri ID
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Adres Alanı
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// İl
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// İlçe
        /// </summary>
        public string County { get; set; }

        /// <summary>
        /// Semt
        /// </summary>
        public string District { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public CustomerAddress() { }

        public override void GetCustomerInfo()
        {
            Console.WriteLine("Adres Bilgileri");
            Console.WriteLine("---------------");
            base.GetCustomerInfo();
            Console.WriteLine($"Müşteri Id : {CustomerId} | Adres : {Address} | İl : {City} | İlçe : {County} | Semt : {District}");
            Console.WriteLine("---------------");
        }
    }
}