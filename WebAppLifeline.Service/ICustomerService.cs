using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAppLifeline.DAL.Models;

namespace WebAppLifeline.Service
{
    public interface ICustomerService
    {
        Task<IList<Customer>> getCustomer();
        Task<Customer> getCustomerByID(int customerID);
        Task<bool> addCustomer(Customer newCustomer);
        Task<bool> updateCustomer(Customer customer);
        Task<bool> delCustomer(int customerID);
    }
}
