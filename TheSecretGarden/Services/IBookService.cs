using TheSecretGarden.Enum;
using TheSecretGarden.Models;

namespace TheSecretGarden.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetBooks();
        Task<IEnumerable<Book>> GetByCategoryAsync(BookCategory BookCategory);
        Task<Book> GetByIdAsync(int id);
        Task AddAsync(Book book);
        Task<Book> UpdateAsync(int id, Book book);
        Task DeleteAsync(int id);
    }
}
