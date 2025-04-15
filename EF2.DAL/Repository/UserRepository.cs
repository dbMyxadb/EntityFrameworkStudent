using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF.DAL.Entities;

namespace EF.DAL
{
    public class UserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository()
        {
            _context = new AppDbContext();
        }
        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public void Add(User User)
        {
            _context.Users.Add(User);
            _context.SaveChanges();
        }
        public void Update(User User)
        {
            _context.Users.Update(User);
            _context.SaveChanges();
        }
        public void Delete(User User)
        {
            _context.Users.Remove(User);
            _context.SaveChanges();
        }
    }
}