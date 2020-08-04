namespace CustomerApp
{
    public class CustomerService
    {
        private Customer customer;

        private CustomerAddress customerAddress;

        public CustomerService()
        {
            customer = new Customer();
            customerAddress = new CustomerAddress();
        }

        public int AddCustomer(string firstName, string lastName, string phoneNumber, string email)
        {
            customer.Id = RandomIntGenerator();
            customer.FirstName = firstName;
            customer.LastName = lastName;
            customer.PhoneNumber = phoneNumber;
            customer.EmailAddress = email;

            return customer.Id;
        }

        public Customer GetCustomerById(int id)
        {
            return customer;
        }

        public void GetCustomerInfo()
        {
            customer.GetCustomerInfo();
        }

        public int AddCustomerAddress(int customerId, string address, string city, string county, string district)
        {
            customerAddress.Id = RandomIntGenerator();
            customerAddress.CustomerId = customerId;
            customerAddress.Address = address;
            customerAddress.City = city;
            customerAddress.County = county;
            customerAddress.District = district;

            return customerAddress.Id;
        }

        public CustomerAddress GetCustomerAddressById(int customerId)
        {
            return customerAddress;
        }

        public void GetCustomerAddressInfo()
        {
            customerAddress.GetCustomerInfo();
        }

        private int RandomIntGenerator()
        {
            var random = new System.Random();
            return random.Next(1, 100);
        }
    }
}