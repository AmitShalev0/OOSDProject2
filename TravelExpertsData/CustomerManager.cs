using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    public static class CustomerManager
    {
        /// <summary>
        /// Customer is authenticated based on username and password 
        /// </summary>
        /// <param name="db">context</param>
        /// <param name="username">username as string</param>
        /// <param name="password">password as string</param>
        /// <returns>a customer if found if not null</returns>
        public static Customer? Authenticate(TravelExpertsContext db, string username, string password)
        {
            var customer = db.Customers.SingleOrDefault
                (cst => cst.CustUserName == username && cst.CustPassword == password);
            return customer;
        }

        /// <summary>
        /// add a new customer
        /// </summary>
        /// <param name="db">context</param>
        /// <param name="customer">customer to add</param>
        public static void AddCustomer(TravelExpertsContext db, Customer customer)
        {
            Customer cst = customer;
            db.Customers.Add(cst);
            db.SaveChanges();
        }
    }
}
