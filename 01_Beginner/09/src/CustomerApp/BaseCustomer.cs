using System;

namespace CustomerApp
{
    /// <summary>
    /// Base Customer class.
    /// </summary>
    public class BaseCustomer
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        public virtual void GetCustomerInfo()
        {
            Console.WriteLine($"Id : {Id} ");
        }
    }
}