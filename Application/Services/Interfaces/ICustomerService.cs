using Application.Contracts.Request.RequestCustomer;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Application.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<IActionResult> GetCustomerByCpf(string cpf);
        Task<IActionResult> GetCustomerById(int id);
        ValueTask<IActionResult> RegisterCustomer(CustomerPostRequest request);
        Task<IActionResult> UpdateCustomer(CustomerPutRequest request);
        Task<IActionResult> RemoveCustomer(int cpf);
        Task<IActionResult> GetAllCustomers();
    }
}
