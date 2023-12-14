using TheSecretGarden.Models;

namespace TheSecretGarden.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer> GetByIdAsync(int id);
        Task AddAsync(Customer customer);
        Task<Customer> UpdateAsync(Customer customer);
    }
}