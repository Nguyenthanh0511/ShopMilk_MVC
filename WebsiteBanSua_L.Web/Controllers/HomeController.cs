using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Data;
using Model.Entities;
using Service.IService;
using System.Diagnostics;
using WebsiteBanSua_L.Web.Models;
using WebsiteBanSua_L.Web.ViewModel;

namespace WebsiteBanSua_L.Web.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly WebsiteBanSua_LContext _context;

        public HomeController(IProductService productService,ICategoryService service, WebsiteBanSua_LContext context)
        {
            _context = context;
            _productService = productService;
            _categoryService = service;
        }

        public async Task<IActionResult> Index()
        {

            var productList = await _productService.GetAll(); // Ensure this returns List<Product>
            
            return View(productList);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ShowProduct()
        {

            var productList = await _productService.GetAll();
            var categoryList = await _categoryService.GetAll();
            var model = Tuple.Create((IEnumerable<Category>)categoryList, (IEnumerable<Product>)productList);
            return View(model);
        }
        public async Task<IActionResult> FilterByCategory(int CategoryId)
        {
            List<Product>  product = await _productService.GetIdByCategory(CategoryId);
            //if(product != null)
                //var products = new List<Product> { product};
            return PartialView("_ProductListPartial", product);
            //return PartialView("_ProductListPartial", new List<Product>());
        }
        [HttpGet]
        public async Task<IActionResult> GetProductDetail(int id)
        {
            //var product1 = await _productService.Get(id);
            var productAll = await _productService.GetAll();

            var product2 = _context.products
                            .Include(p=>p.Category)
                            .FirstOrDefault(p => p.Id == id );

            var ImageList = _context.images
                            .Where(i => i.ProdId == id)
                            .ToList();

            var query = _context.images
                        .Where(i => i.ProdId == 1)
                        .ToList() ;
            Console.WriteLine("truy van :",query);
            if (ImageList == null)
            {
                // Log hoặc xử lý nếu không có hình ảnh nào được tìm thấy
                // Bạn có thể ghi log hoặc trả về một thông báo lỗi hoặc một view khác
                return NotFound("No images found for this product.");
            }
            if (_productService.Flag != null)
            {
                var productDetailViewModel = new ProductDetailViewModel
                {
                    product = product2,
                    listProduct = productAll,
                    listImage = ImageList
                };
                return View(productDetailViewModel);
            }
            else
            {
                return BadRequest(_productService.Error);
            }
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Create(category);
                if (_categoryService.Flag)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return BadRequest(_categoryService.Error);
                }

            }
            return View(category);
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
