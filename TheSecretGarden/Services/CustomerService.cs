using Microsoft.EntityFrameworkCore;
using TheSecretGarden.Enum;
using TheSecretGarden.Models;

namespace TheSecretGarden.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly BookStoreDbContext _context;
        public CustomerService(BookStoreDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            var result = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            var result = await _context.Customers.OrderByDescending(p => p.Id).ToListAsync();
            return result;
        }

        public async Task<Customer> GetByUsernameAndPasswordAsync(Customer customer)
        {
            var result = await _context.Customers.FirstOrDefaultAsync(x => x.Username == customer.Username && x.Password == customer.Password);
            return result;
        }

        public async Task<Customer> UpdateAsync(Customer customer)
        {
            _context.Update(customer);
            await _context.SaveChangesAsync();
            return customer;
        }
    }
}
