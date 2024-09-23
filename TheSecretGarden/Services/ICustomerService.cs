using TheSecretGarden.Enum;
using TheSecretGarden.Models;

namespace TheSecretGarden.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer> GetByIdAsync(int id);
        Task<Customer> GetByUsernameAndPasswordAsync(Customer customer);
        Task<Customer> GetByUsername(string username);
        Task AddAsync(Customer customer);
        Task StoreGoogleData(string name, string username, string email, string password, DateTime dateregistered);
        Task<Customer> UpdateAsync(Customer customer);
    }
}