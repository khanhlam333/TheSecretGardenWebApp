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
        public async Task AddAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
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

        public async Task UpdateAsync(int id, Book book)
        {
            throw new NotImplementedException();
        }
    }
}
