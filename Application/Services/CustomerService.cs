using Application.Services.Interfaces;
using Domain.Base;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IActionResult> RegisterCustomer(Customer customer)
        {
            try
            {
                var returnGetCustomerByCpf = await _customerRepository.GetCustomerByCPF(customer.Cpf);

                if (returnGetCustomerByCpf == null)
                {
                    var returnAddCustomer = await _customerRepository.AddCustomer(customer);

                    if (returnAddCustomer != null)
                        return new ResultObject(HttpStatusCode.OK, new { Success = "Conta cadastrada com sucesso" });
                    else
                        return new ResultObject(HttpStatusCode.BadRequest, new { Error = "Houve um erro ao realizar o cadastro da conta" });
                }
                else
                    return new ResultObject(HttpStatusCode.AlreadyReported, new { Warn = "O CPF informado já possui cadastro" });
            }
            catch (Exception ex)
            {
                return new ResultObject(HttpStatusCode.InternalServerError, new { Error = ex.Message });
            }
        }

        public async Task<IActionResult> GetCustomerByCpf(string cpf)
        {
            try
            {
                Customer customer = await _customerRepository.GetCustomerByCPF(cpf);

                if (customer == null)
                    return new ResultObject(HttpStatusCode.NotFound, new { Info = "CPF não encontrado" });
                else
                    return new ResultObject(HttpStatusCode.OK, customer);
            }
            catch (Exception ex)
            {
                return new ResultObject(HttpStatusCode.InternalServerError, new { Error = ex.Message });
            }
        }

        public async Task<IActionResult> GetCustomerById(int id)
        {
            Customer customer = new Customer();

            try
            {
                customer = await _customerRepository.GetCustomerById(id);

                if (customer == null)
                    return new ResultObject(HttpStatusCode.NotFound, new { Info = "Cliente não encontrado" });
                else
                    return new ResultObject(HttpStatusCode.OK, customer);
            }
            catch (Exception ex)
            {
                return new ResultObject(HttpStatusCode.InternalServerError, new { Error = ex.Message });
            }
        }

        public List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                return customers = _customerRepository.GetCustomers();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IActionResult> UpdateCustomer(Customer customer)
        {
            try
            {
                Customer returnGetCustomerByCpf = await _customerRepository.GetCustomerByCPF(customer.Cpf);

                if (returnGetCustomerByCpf != null)
                {
                    returnGetCustomerByCpf.Name = customer.Name;
                    returnGetCustomerByCpf.Cellphone = customer.Cellphone;
                    returnGetCustomerByCpf.Email = customer.Email;
                    returnGetCustomerByCpf.Birthdate = customer.Birthdate;

                    var returnUpdateCustomer = _customerRepository.UpdateCustomer(returnGetCustomerByCpf);

                    if(returnUpdateCustomer != null)
                        return new ResultObject(HttpStatusCode.OK, new { Success = "Dados cadastrais alterados com sucesso" });
                    else
                        return new ResultObject(HttpStatusCode.BadRequest, new { Error = "Houve um erro ao realizar o cadastro da conta" });
                }
                else
                    return new ResultObject(HttpStatusCode.AlreadyReported, new { Warn = "Cadastro de cliente não encontrado" });
            }
            catch (Exception ex)
            {
                return new ResultObject(HttpStatusCode.InternalServerError, new { Error = ex.Message });
            }
        }

        public async Task<IActionResult> RemoveCustomer(int id)
        {
            try
            {
                Customer returnGetCustomerByCpf = await _customerRepository.GetCustomerById(id);

                if (returnGetCustomerByCpf != null)
                {
                     _customerRepository.RemoveCustomer(returnGetCustomerByCpf);
                        return new ResultObject(HttpStatusCode.OK, new { Success = "Conta removida com sucesso" });
                }
                else
                    return new ResultObject(HttpStatusCode.AlreadyReported, new { Warn = "Cadastro de cliente não encontrado" });
            }
            catch (Exception ex)
            {
                return new ResultObject(HttpStatusCode.InternalServerError, new { Error = ex.Message });
            }
        }
    }
}
