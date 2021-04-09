using System.Linq;

namespace Sports_Store.Models
{
    public class EfProductRepository : IProductRepository
    {
        private AppDBContext _context;
        public EfProductRepository (AppDBContext context)
        {
            _context = context;
        }
        public Product Create(Product p)
        {
            _context.Products.Add(p);
            _context.SaveChanges();
            return p;
        }
        public IQueryable<string> GetAllCategories()
        {
            IQueryable<string> categories = _context.Products
                                                    .Select(p => p.Category)
                                                    .Distinct();
            return categories;
        }

        public IQueryable<Product> GetAllProducts()
        {
            return _context.Products;
        }

        public Product GetProductById(int productId)
        {
            //Product p = _context.Products
            //                    .Where(p => p.ProductId == productId)
            //                    .FirstOrDefault();
            Product p = _context.Products.Find(productId);
            return p;
        }

        public IQueryable<Product> GetProductsByKeyword(string keyword)
        {
            IQueryable<Product> products = _context.Products
                                                   .Where(p => p.Name.Contains(keyword));
            return products;
        }
        public Product UpdateProduct(Product p)
        {
            Product productToUpdate = _context.Products.Find(p.ProductId);
            if (productToUpdate != null)
            {
                productToUpdate.Category = p.Category;
                productToUpdate.Description = p.Description;
                productToUpdate.Name = p.Name;
                productToUpdate.Price = p.Price;
                _context.SaveChanges();
            }
            return productToUpdate;
        }
        public bool DeleteProduct(int id)
        {
            Product productToDelete = GetProductById(id);
            if (productToDelete == null)
            {
                return false;
            }
            _context.Products.Remove(productToDelete);
            _context.SaveChanges();
            return true;
        }

    }
}
