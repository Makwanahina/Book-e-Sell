using BookStore1.Models.Models;

namespace BookStore1.Repository
{
    public class BaseRepository
    {
        protected readonly BookStore1Context _context = new BookStore1Context();
    }
}
