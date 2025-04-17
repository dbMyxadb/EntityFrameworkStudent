
using EF.DAL.Entities;

namespace EF.DAL
{
    public class ProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository()
        {
            _context = new AppDbContext();
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products;
        }

        public void Add(Product Product)
        {
            _context.Products.Add(Product);
            _context.SaveChanges();

        }
        public void Add(List<Product> Product)
        {
            _context.Products.AddRange(Product);
            _context.SaveChanges();

        }


        public void Update(Product Product)
        {
             _context.Products.Update(Product);
            _context.SaveChanges();
        }
        public void Update(List<Product> Product)
        {
            _context.Products.UpdateRange(Product);
            _context.SaveChanges();
        }


        public void Delete(Product Product)
        {
            _context.Products.Remove(Product);
            _context.SaveChanges();
        }
        public void Delete(List<Product> Product)
        {
            _context.Products.RemoveRange(Product);
            _context.SaveChanges();
        }
    }
}
