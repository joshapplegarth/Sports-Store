using Microsoft.AspNetCore.Mvc;
using Sports_Store.Models;
using System.Linq;

namespace Sports_Store.Controllers
{
    public class HomeController : Controller
    {

        private int _pageSize = 4;
        private IProductRepository _repository;

        public HomeController(IProductRepository repository) // Dependency Injection
                                                             // Inversion of Control
        {
            _repository = repository;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Product p)
        {
            _repository.Create(p);
            return RedirectToAction("Index");
        }


        //public IActionResult Index()
        //{
        //    //IQueryable<Product> allProducts;
        //    //allProducts = _repository.GetAllProducts();
        //    //
        //    //return View(allProducts);
        //    return View(_repository.GetAllProducts());
        //}
        public IActionResult Categories()
        {
            IQueryable<string> categories = _repository.GetAllCategories();
            IQueryable<string> lengthCategories = categories.OrderBy(s => s.Length)
                                                            .ThenBy(s => s);
            return View(lengthCategories); 
        }
        public IActionResult Index(int productPage = 1)
        {
            IQueryable<Product> allProducts = _repository.GetAllProducts();
            IQueryable<Product> someProducts = allProducts.OrderBy(p => p.ProductId)
                                                          .Skip((productPage - 1) * _pageSize)
                                                          .Take(_pageSize);
            return View(someProducts);

        }
        public IActionResult Details(int productId)
        {
            Product p = _repository.GetProductById(productId);
            if (p != null)
            {
                return View(p);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Search(string keyword)
        {
            IQueryable<Product> productsWithKeyword = _repository.GetProductsByKeyword(keyword);
            
            ViewBag.Search = keyword;

            return View(productsWithKeyword);
        }
        [HttpGet]
        public IActionResult Update( int id)
        {
            Product p = _repository.GetProductById(id);
            if (p != null)
            {
                return View(p);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Update(Product p)
        {
            Product updateProduct = _repository.UpdateProduct(p);
            //return RedirectToAction("Index");
            return RedirectToAction("Details", new { productId = p.ProductId });
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Product p = _repository.GetProductById(id);
            if (p != null)
            {
                return View(p);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete2 (int id)
        {
            _repository.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}
