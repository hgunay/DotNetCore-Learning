namespace CustomerApp
{
    /// <summary>
    /// Customer Class
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Müşteri Id
        /// </summary>
        public int Id;

        /// <summary>
        /// Müşteri Adı 
        /// </summary>
        public string FirstName;

        /// <summary>
        /// Müşteri Soyadı
        /// </summary>
        public string LastName;

        /// <summary>
        /// Müşteri Telefon No
        /// </summary>
        public string PhoneNumber;

        /// <summary>
        /// Müşteri E-posta Adresi
        /// </summary>
        public string EmailAddress;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Customer()
        {

        }

        /// <summary>
        /// Customer Id parametresi alan diğer constructor.
        /// </summary>
        /// <param name="customerId">Customer Id.</param>
        public Customer(int customerId)
        {
            this.Id = customerId;
        }

        /// <summary>
        /// Müşterinin ad soyad bilgisini dönen metod'dur.
        /// </summary>
        /// <value>Ad Soyad.</value>
        public string FullName()
        {
            var fullName = string.Empty;
            if(!string.IsNullOrEmpty(FirstName))
            {
                if(!string.IsNullOrEmpty(LastName))
                {
                    fullName = $"{FirstName} {LastName}";
                    return fullName;
                }

                fullName = FirstName;
            }

            return fullName;
        }
    }
}