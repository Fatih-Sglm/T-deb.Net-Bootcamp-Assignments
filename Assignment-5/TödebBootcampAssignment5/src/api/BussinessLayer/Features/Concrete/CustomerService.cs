using AutoMapper;
using Bussines.Configuration.Extensions;
using System.Collections.Generic;
using System.Linq;
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
        private readonly ICustomerRepository _userRepository;
        private readonly IMapper _mapper;
        public CustomerService(ICustomerRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<CreateCustomerDto> AddAsync(CreateCustomerDto createCustomer)
        {
            var validator = new CreateCustomerValidate();
            validator.Validate(createCustomer).ThrowIfException();
            await _userRepository.AddAsync(_mapper.Map<Customer>(createCustomer));
            await _userRepository.SaveChangeAsync();
            return createCustomer;
        }

        public IEnumerable<GetCustomerDto> GetAll()
        {
            return _userRepository.GetAll().Select(x => _mapper.Map<GetCustomerDto>(x)).ToList();
        }

        public async Task<Customer> GetAsync(string id)
        {
            return await _userRepository.GetAsync(id);
        }

        public async Task Remove(Customer customer)
        {
            _userRepository.Remove(customer);
            await _userRepository.SaveChangeAsync();
        }

        public async Task<UpdateCustomerDto> Update(UpdateCustomerDto updateCustomer)
        {
            var validator = new UpdateCustomerValidate();
            validator.Validate(updateCustomer).ThrowIfException();
            var user = _mapper.Map<Customer>(updateCustomer);
            _userRepository.Update(user);
            await _userRepository.SaveChangeAsync();
            return updateCustomer;
        }
    }
}
