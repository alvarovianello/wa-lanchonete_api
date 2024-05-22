using Application.Contracts.Request;
using Application.Services.Interfaces;
using Application.Validators;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public CustomerService(
                                ICustomerRepository customerRepository,
                                IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async ValueTask<IActionResult> RegisterCustomer(CustomerPostRequest request)
        {
            try
            {
                var validator = await new CustomerPostRequestValidator().ValidateAsync(request);

                if (!validator.IsValid)
                    return new ResultObject(HttpStatusCode.BadRequest, validator);

                var returnGetCustomerByCpf = await _customerRepository.GetCustomerByCPF(request.Cpf);

                if (returnGetCustomerByCpf == null)
                {
                    Customer customer = _mapper.Map<Customer>(request);
                    await _customerRepository.AddCustomer(customer);

                    if (customer != null)
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

        public async Task<IActionResult> GetAllCustomers(string name, string email)
        {
            try
            {
                var listCustomers = await _customerRepository.GetAllCustomer(name, email);
                return new ResultObject(HttpStatusCode.OK, listCustomers);
            }
            catch (Exception ex)
            {

                return new ResultObject(HttpStatusCode.BadRequest, ex);
            }
        }

        public async Task<IActionResult> UpdateCustomer(CustomerPutRequest customer)
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

                    if (returnUpdateCustomer != null)
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
