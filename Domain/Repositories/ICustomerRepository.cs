using Domain.Entities;

namespace Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> AddCustomer(Customer customer);
        Task<Customer> GetCustomerByCPF(string cpf);
        Task<Customer> GetCustomerById(int id);
        Customer UpdateCustomer(Customer customer);
        void RemoveCustomer(Customer customer);
        List<Customer> GetCustomers();
    }
}
