using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TödebBootcampAssignment4.DTOs.Customer;
using TödebBootcampAssignment4.EntityLayer.Entities;

namespace TödebBootcampAssignment4.BusinessLayer.Features.Abstract
{
    public interface ICustomerService
    {

        IEnumerable<GetCustomerDto> GetAll();
        Task<CreateCustomerDto> AddAsync(CreateCustomerDto createCustomer);
        Task<UpdateCustomerDto> Update(UpdateCustomerDto updateCustomer);
        Task Remove(Customer customer);
        Task<Customer> GetAsync(string id);

        Customer Get(Expression<Func<Customer, bool>> predicate);
    }
}
