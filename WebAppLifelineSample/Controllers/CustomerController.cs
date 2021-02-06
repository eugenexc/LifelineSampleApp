using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAppLifeline.DAL.Models;
using WebAppLifeline.Service;

namespace WebAppLifeline.Web.Controllers
{

    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _svc;
        public CustomerController(ICustomerService customerService)
        {
            this._svc = customerService;
        }

        [Route("api/[controller]")]
        [HttpGet]
        public async Task<IEnumerable<Customer>> Get()
        {
            return await this._svc.getCustomer();
        }

        [Route("api/Customer/{id:int}")]
        public async Task<Customer> Get(int id)
        {
            return await this._svc.getCustomerByID(id);
        }

        [Route("api/[controller]")]
        [HttpPost]
        public async Task<bool> AddCustomer(Customer newCustomer)
        {
            return await this._svc.addCustomer(newCustomer);
        }

        [Route("api/[controller]")]
        [HttpPut]
        public async Task<bool> UpdateCustomer(Customer customer)
        {
            return await this._svc.updateCustomer(customer);
        }

        [Route("api/[controller]/{id:int}")]
        [HttpDelete]
        public async Task<bool> DeleteCustomer(int id)
        {
            return await this._svc.delCustomer(id);
        }
    }
}
