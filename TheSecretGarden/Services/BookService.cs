using Microsoft.EntityFrameworkCore;
using TheSecretGarden.Enum;
using TheSecretGarden.Models;

namespace TheSecretGarden.Services
{
    public class BookService : IBookService
    {
        private readonly BookStoreDbContext _context;
        public BookService(BookStoreDbContext context)
        {
            _context = context;
        }
        public Task AddAsync(Book book)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            var result = await _context.Books.ToListAsync();
            return result;
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            var result = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<IEnumerable<Book>> GetByCategoryAsync(BookCategory BookCategory)
        {
            var result = await _context.Books.Where(x => x.BookCategory == BookCategory).ToListAsync();
            return result;
        }

        public Task UpdateAsync(int id, Book book)
        {
            throw new NotImplementedException();
        }
    }
}
