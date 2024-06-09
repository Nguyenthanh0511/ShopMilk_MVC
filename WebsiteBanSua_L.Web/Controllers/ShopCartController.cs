using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Data;
using Model.Entities;
using Service.IService;
using Service.Service;
using WebsiteBanSua_L.Web.ViewModel;

namespace WebsiteBanSua_L.Web.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly ICartDetailService _cartDetailService;
        private readonly WebsiteBanSua_LContext _context;
        private readonly IUserService _userService;
        public ShopCartController(ICartDetailService cartDetailService, WebsiteBanSua_LContext context, IUserService userService)
        {
            _cartDetailService = cartDetailService;
            _context = context;
            _userService = userService;
        }

        public async Task<IActionResult> ShowCart(int userId = 2)
        {
            var user = await _userService.Get(userId); // Assuming you have a method to get user by ID
            var cartDetail = await _cartDetailService.GetAll(); // Assuming you have a method to get cart details by user ID
            var listProducts = new List<Product>();

            foreach (var detail in cartDetail)
            {
                var product = await _context.products.FindAsync(detail.ProdId); // Assuming you have a method to get product by ID
                listProducts.Add(product);
            }

            var cartViewModel = new CartViewModel
            {
                user = user,
                listProduct = listProducts
            };

            return View(cartViewModel);
        }

        //[HttpGet]
        //public async Task<IActionResult> ShowCart()
        //{
        //    var cartDetail = await _cartDetailService.GetAll();
        //    //var products = await _context.products.ToListAsync(); // Ensure 'Products' is correctly referenced

        //    //var listCartProduct = (from list in cartDetail
        //    //                       join p in products
        //    //                       on list.ProdId equals p.Id
        //    //                       where list.UserId == userId
        //    //                       select new { list, p }).ToList();

        //    //var cartView = new CartViewModel()
        //    //{
        //    //    UserId = userId,
        //    //    listProduct = listCartProduct.Select(lp => lp.p).ToList(),
        //    //    quantity = listCartProduct.Sum(c => c.list.Quantity)
        //    //};

        //    return View(cartDetail);
        //}

        [HttpPost]
        public async Task<IActionResult> AddCart(int userId, int productId, int quantity)
        {
            // Find cart details for the specified user and product
            var cad = _context.cartsDetail.FirstOrDefault(c => c.UserId == userId && c.ProdId == productId);

            // Find the product
            var product = await _context.products.FindAsync(productId);

            if (product != null)
            {
                if (cad == null)
                {
                    // Create new cart detail if it doesn't exist
                    var cartDetail = new CartDetail()
                    {
                        ProdId = productId,
                        UserId = userId,
                        Quantity = quantity,
                        DateBuy = DateTime.Now,
                        Total = product.Price * quantity  // Calculate total based on product price and quantity
                    };
                    await _cartDetailService.Create(cartDetail);
                }
                else
                {
                    // Update existing cart detail
                    cad.Quantity += quantity;
                    cad.DateBuy = DateTime.Now;
                    cad.Total = product.Price * cad.Quantity; // Update total based on updated quantity

                    await _cartDetailService.Update(cad);
                }
            }
            else
            {
                // Handle the case where the product doesn't exist
                return NotFound("Product not found.");
            }

            return Ok("Cart item added successfully");
        }

    }
}
