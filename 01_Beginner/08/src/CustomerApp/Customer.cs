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
        public string FirstName { get; set; }

        /// <summary>
        /// Müşteri Soyadı
        /// </summary>
        private string _lastName;

        public string LastName
        {
            get => _lastName;
            set => _lastName = value;
        }

        /// <summary>
        /// Müşteri Telefon No
        /// </summary>
        public string PhoneNumber;

        /// <summary>
        /// Müşteri E-posta Adresi
        /// </summary>
        private string _emailAddress = "@";

        public string EmailAddress
        {
            get
            {
                return _emailAddress;
            }
            set
            {
                if (value.Contains(_emailAddress))
                {
                    _emailAddress = value;
                }
                else
                {
                    throw new System.Exception("E-posta adresi formatı hatalı!");
                }
            }
        }

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
            if (!string.IsNullOrEmpty(FirstName))
            {
                if (!string.IsNullOrEmpty(LastName))
                {
                    fullName = $"{FirstName} {LastName}";
                    return fullName;
                }

                fullName = FirstName;
            }

            return fullName;
        }

        public string CustomerFullName => $"{FirstName} {LastName}";
    }
}