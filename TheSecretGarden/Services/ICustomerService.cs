using TheSecretGarden.Enum;
using TheSecretGarden.Models;

namespace TheSecretGarden.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer> GetByIdAsync(int id);
        Task<Customer> GetByUsernameAndPasswordAsync(Customer customer);
        Task AddAsync(Customer customer);
        Task<Customer> UpdateAsync(Customer customer);
    }
}