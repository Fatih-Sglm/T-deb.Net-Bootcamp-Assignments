using AutoMapper;
using Bussines.Configuration.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TödebBootcampAssignment4.BusinessLayer.Configuration.Validations;
using TödebBootcampAssignment4.BusinessLayer.Features.Abstract;
using TödebBootcampAssignment4.DataAccesLayer.Features.Abstract;
using TödebBootcampAssignment4.DTOs.Customer;
using TödebBootcampAssignment4.EntityLayer.Entities;

namespace TödebBootcampAssignment4.BusinessLayer.Features.Concrete
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerService(ICustomerRepository userRepository, IMapper mapper)
        {
            _customerRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<CreateCustomerDto> AddAsync(CreateCustomerDto createCustomer)
        {
            var validator = new CreateCustomerValidate();
            validator.Validate(createCustomer).ThrowIfException();
            var user = _mapper.Map<Customer>(createCustomer);
            await _customerRepository.AddAsync(user);
            await _customerRepository.SaveChangeAsync();
            return createCustomer;
        }

        public Customer Get(Expression<Func<Customer, bool>> predicate)
        {
            return _customerRepository.Get(predicate);
        }

        public IEnumerable<GetCustomerDto> GetAll()
        {
            return _customerRepository.GetAll().Select(x => _mapper.Map<GetCustomerDto>(x)).ToList();
        }

        public async Task<Customer> GetAsync(string id)
        {
            return await _customerRepository.GetAsync(id);
        }

        public async Task Remove(Customer customer)
        {
            _customerRepository.Remove(customer);
            await _customerRepository.SaveChangeAsync();
        }

        public async Task<UpdateCustomerDto> Update(UpdateCustomerDto updateCustomer)
        {
            var validator = new UpdateCustomerValidate();
            validator.Validate(updateCustomer).ThrowIfException();
            var user = _mapper.Map<Customer>(updateCustomer);
            _customerRepository.Update(user);
            await _customerRepository.SaveChangeAsync();
            return updateCustomer;
        }
    }
}
