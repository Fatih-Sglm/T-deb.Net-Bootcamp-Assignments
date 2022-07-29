using System.Collections.Generic;
using System.Threading.Tasks;
using TödebBootcampAssignment4.EntityLayer.Entities;

namespace TödebBootcampAssignment4.DataAccesLayer.Features.Abstract
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();
        Task AddAsync(Customer customer);
        void Update(Customer customer);
        void Remove(Customer customer);
        Task<Customer> GetAsync(string id);

        Task<int> SaveChangeAsync();
    }
}
