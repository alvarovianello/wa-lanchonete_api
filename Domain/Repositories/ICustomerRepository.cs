using Domain.Entities;

namespace Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task AddCustomer(Customer customer);
        Task<Customer> GetCustomerByCPF(string cpf);
        Task<IEnumerable<Customer>> GetAllCustomer();
        Task<Customer> GetCustomerById(int id);
        Task UpdateCustomer(Customer customer);
        Task RemoveCustomer(Customer customer);
    }
}
