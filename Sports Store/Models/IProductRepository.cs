using System.Linq;

namespace Sports_Store.Models
{
    public interface IProductRepository
    {
        public Product Create(Product p);
       
        public IQueryable<string> GetAllCategories();

        public IQueryable<Product> GetAllProducts();

        public Product GetProductById(int productId);

        public IQueryable<Product> GetProductsByKeyword(string keyword);

        public Product UpdateProduct(Product p);
        public bool DeleteProduct(int id);
        

    }
}
