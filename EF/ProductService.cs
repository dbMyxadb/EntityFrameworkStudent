using EF.DAL.Entities;
using EF.DAL;
using Microsoft.Identity.Client;
namespace EF
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;
        public ProductService()
        {
            _productRepository = new ProductRepository();
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepository.GetAll();
        }
        public void ShowAllProducts()
        {
            var products = GetAllProducts();
            foreach (var product in products)
            {
                Console.WriteLine($"Product ID: {product.Id}, Name: {product.Name}, Price: {product.Price}");
            }
        }   
        public void AddProduct(Product product)
        {
            _productRepository.Add(product);
        }
        public void UpdateProduct(int id,Product prod1)
        {

            var Product = _productRepository.GetAll().FirstOrDefault(u => u.Id == id);
            if (Product != null)
            {
                Product.Name = prod1.Name;
                Product.Price = prod1.Price;
                _productRepository.Update(Product);
            }
        }
        public void DeleteProduct(Product product)
        {
            _productRepository.Delete(product);
        }
    }
}
