using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppLifeline.DAL;
using WebAppLifeline.DAL.Models;

namespace WebAppLifeline.Service
{
    public class CustomerService: ICustomerService
    {
        private LifelineContext _dbContext;
        public CustomerService(LifelineContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IList<Customer>> getCustomer(){
            return await _dbContext.Customers.ToListAsync();
        }

        public async Task<Customer> getCustomerByID(int customerID)
        {
            return await _dbContext.Customers
                .Include(c => c.City)
                .FirstOrDefaultAsync(c => c.CustomerID == customerID);
        }

        public async Task<bool> addCustomer(Customer newCustomer)
        {
            var result = _dbContext.Add(newCustomer);
            var cnt = await _dbContext.SaveChangesAsync();
            return cnt >= 1;
        }

        public async Task<bool> updateCustomer(Customer customer)
        {
            var dbCustomer = _dbContext.Update(customer);
            var cnt = await _dbContext.SaveChangesAsync();
            return cnt >= 1;
        }

        public async Task<bool> delCustomer(int customerID)
        {
            var customer = await _dbContext.Customers.FindAsync(customerID);
            var result = _dbContext.Remove(customer);
            return result != null;
        }
    }
}
