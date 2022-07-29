using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TödebBootcampAssignment4.DataAccesLayer.Context;
using TödebBootcampAssignment4.DataAccesLayer.Features.Abstract;
using TödebBootcampAssignment4.EntityLayer.Entities;

namespace TödebBootcampAssignment4.DataAccesLayer.Features.Concrete
{
    public class CustomerRepository : ICustomerRepository
    {
        private BookingDbContext _ct;
        public CustomerRepository(BookingDbContext context)
        {
            _ct = context;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _ct.Customers.ToList();
        }

        public async Task<Customer> GetAsync(string id)
        {
            return await _ct.Customers.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
        }

        public async Task AddAsync(Customer customer)
        {
            await _ct.Customers.AddAsync(customer);
        }

        public void Remove(Customer customer)
        {
            _ct.Remove(customer);
        }

        public void Update(Customer customer)
        {
            _ct.Update(customer);
        }

        public async Task<int> SaveChangeAsync()
        {
            return await _ct.SaveChangesAsync();
        }
    }
}
