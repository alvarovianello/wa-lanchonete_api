using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly LanchoneteDbContext _context;
        public CustomerRepository(LanchoneteDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            _context.Add(customer);
            _context.SaveChanges();

            return customer;
        }

        public async Task<Customer> GetCustomerByCPF(string cpf)
        {
            return await _context.Set<Customer>().FirstOrDefaultAsync(c => c.Cpf.Equals(cpf));
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await _context.Set<Customer>().FirstOrDefaultAsync(c => c.Id.Equals(id));
        }

        public Customer UpdateCustomer(Customer customer)
        {
            _context.Update(customer);
            _context.SaveChanges();

            return customer;
        }

        public void RemoveCustomer(Customer customer)
        {
            _context.Remove(customer);
            _context.SaveChanges();
        }

        public List<Customer> GetCustomers()
        {
            return _context.Set<Customer>().OrderBy(c => c.Name).ToList();
        }
    }
}
