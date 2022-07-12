using BookStore1.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore1Repository
{
    public class UserRepository
    {
        BookStore1Context _context = new BookStore1Context();

        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }
    }
}
