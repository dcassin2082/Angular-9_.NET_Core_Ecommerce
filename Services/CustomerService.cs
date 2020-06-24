using JungleApi.Web.Models;
using JungleApi.Web.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JungleApi.Web.Services
{
    public class CustomerService : ServicesBase, ICustomerService
    {
        private readonly IRepository<Customer> _customerRepo;

        public CustomerService()
        {
            _customerRepo = _customerRepo ?? (_customerRepo = new Repository<Customer>(_dbContext));
        }

        public async Task<Customer> DeleteCustomer(Customer customer)
        {
            return await _customerRepo.Delete(customer);
        }

        public async Task<Customer> GetCustomer(int id)
        {
            return await _customerRepo.Get(id);
        }

        public async Task<Customer> GetCustomer(Expression<Func<Customer, bool>> predicate)
        {
            return await _customerRepo.Get(predicate);
        }

        public async Task<List<Customer>> GetCustomers()
        {
            return await _customerRepo.GetAll();
        }

        public async Task<List<Customer>> GetCustomers(Expression<Func<Customer, bool>> predicate)
        {
            return await _customerRepo.GetAll(predicate);
        }

        public async Task<Customer> PostCustomer(Customer customer)
        {
            return await _customerRepo.Post(customer);
        }

        public async Task<Customer> PutCustomer(Customer customer)
        {
            return await _customerRepo.Put(customer);
        }
    }
}
