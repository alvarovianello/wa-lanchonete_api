using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Application.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<IActionResult> GetCustomerByCpf(string cpf);
        Task<IActionResult> GetCustomerById(int id);
        Task<IActionResult> RegisterCustomer(Customer customer);
        Task<IActionResult> UpdateCustomer(Customer customer);
        Task<IActionResult> RemoveCustomer(int cpf);
        List<Customer> GetCustomers();
    }
}
