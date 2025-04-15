using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF.DAL.Entities;

namespace EF.DAL
{
    public class OrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository()
        {
            _context = new AppDbContext();
        }
        public IEnumerable<Order> GetAll()
        {
            return _context.Orders;
        }

        public void Add(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
        public void Update(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
        }
        public void Delete(Order order)
        {
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }
    }
}