using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
            var result = await _context.Books.FirstOrDefaultAsync(n => n.Id == id);
            _context.Books.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            var result = await _context.Books.OrderByDescending(p => p.Id).ToListAsync();
            return result;
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            var result = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<IEnumerable<Book>> GetByCategoryAsync(BookCategory BookCategory)
        {
            var result = await _context.Books.Where(x => x.BookCategory == BookCategory).OrderByDescending(p => p.Id).ToListAsync();
            return result;
        }

        public async Task<Book> UpdateAsync(int id, Book book)
        {
            _context.Update(book);
            await _context.SaveChangesAsync();
            return book;
        }
    }
}
