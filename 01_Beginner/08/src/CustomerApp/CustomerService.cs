namespace CustomerApp
{
    public class CustomerService
    {
        /// <summary>
        /// Müşteri Id'sine göre müşteri bilgilerini getirir.
        /// </summary>
        /// <param name="id">Müşteri Id.</param>
        /// <returns>Müşteri bilgileri.</returns>
        public Customer GetCustomerById(int id)
        {
            if(id <= 0){
                return null;
            }

            var customer = new Customer(id);

            if(id == 1)
            {
                customer.FirstName = "Anakin";
                customer.LastName = "Skywalker";
                customer.EmailAddress = "anakin@skywalker.com";

                return customer;
            }
            
            return null;
        }
    }
}