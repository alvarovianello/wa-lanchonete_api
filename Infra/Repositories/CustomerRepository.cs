﻿using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infra.Data.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(LanchoneteDbContext context):base(context){}

        public async Task AddCustomer(Customer customer)
        {
            await CreateAsync(customer);
        }
        public async Task<Customer> GetCustomerByCPF(string cpf)
        {
            Expression<Func<Customer,bool>> predicate = entity => entity.Cpf == cpf;
            return await GetSingleAsync(predicate);
        }

        public async Task<IEnumerable<Customer>> GetAllCustomer(string name, string email)
        {
            Expression<Func<Customer, bool>> predicate = entity => 
                               (string.IsNullOrEmpty(name) || entity.Name.Contains(name))
                            && (string.IsNullOrEmpty(email) || entity.Email.Equals(email));

            return await GetListByFilterAsync(predicate, customer => customer.Name);
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            Expression<Func<Customer, bool>> predicate = entity => entity.Id == id;
            return await GetSingleAsync(predicate);
        }

        public async Task UpdateCustomer(Customer customer)
        {
            await UpdateAsync(customer);
        }

        public async Task RemoveCustomer(Customer customer)
        {
           await DeleteAsync(customer);
        }

    }
}
