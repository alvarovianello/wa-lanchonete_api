using Application.Services.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Cryptography.Xml;
using System.Text;

namespace wa_lanchonete_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterCustomer(Customer customer)
        {
            var returnRegisterCustomer = await _customerService.RegisterCustomer(customer);

            if (returnRegisterCustomer == null)
                return NotFound();

            return Ok(returnRegisterCustomer);
        }

        [HttpGet("{cpf}")]
        public async Task<IActionResult> GetCustomerByCpf(string cpf)
        {
            var customer = await _customerService.GetCustomerByCpf(cpf);

            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _customerService.GetCustomerById(id);

            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        [HttpGet]
        public List<Customer> GetCustomers()
        {
            List<Customer> customers = _customerService.GetCustomers();

            //if (customers.Count().Equals(0))
            //    return customers;

            return customers;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(Customer customer)
        {
            var returnUpdateCustomer = await _customerService.UpdateCustomer(customer);

            if (returnUpdateCustomer == null)
                return NotFound();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCustomer(int id)
        {
            var returnUpdateCustomer = await _customerService.RemoveCustomer(id);

            if (returnUpdateCustomer == null)
                return NotFound();

            return Ok();
        }
    }
}
