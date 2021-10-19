using System;
using System.Threading.Tasks;
using Models;
using Microsoft.EntityFrameworkCore;

namespace DL
    {
    public class Repo : IRepo
    {
        private DBContext _context;
        public Repo(DBContext dbcontext)
        {
            _context = dbcontext;
        }
        public async Task<User> CreateUserAsync(User user)
        {
            await _context.AddAsync(user);

            await _context.SaveChangesAsync();

            _context.ChangeTracker.Clear();

            return user;
        }
    }
}
