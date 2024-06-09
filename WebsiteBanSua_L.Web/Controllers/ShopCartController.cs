using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Data;
using Service.IService;
using WebsiteBanSua_L.Web.ViewModel;

namespace WebsiteBanSua_L.Web.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly ICartDetailService cartDetailService;
        private readonly WebsiteBanSua_LContext _context;
        public ShopCartController(ICartDetailService cartDetailService, WebsiteBanSua_LContext context)
        {
            _context = context;
            this.cartDetailService = cartDetailService;
        }
        [HttpGet]
        public async Task<IActionResult> AddCart(int userId)
        {
            var cartDetail = await cartDetailService.GetAll();
            var products = await _context.products.ToListAsync();
            var listCartProduct = (from list in cartDetail
                                   join p in products
                                   on list.ProdId equals p.Id
                                   where list.UserId == userId
                                   select list).ToList();

            var cartView = new CartViewModel()
            {
                UserId = userId,
                listProduct = products,
                quantity = listCartProduct.Sum(c => c.Quantity)
            };
            return View(cartDetail);
        }
        [HttpPost]
        public async Task<IActionResult> AddCart(int userId, int productId,int quantity)
        {
            cartDetailService.addCart(userId, productId, quantity);
            if (cartDetailService.Flag)
            {
                return Ok("Cart item added successfully");
            }
            else
            {
                return BadRequest(cartDetailService.Error);
            }
        }
    }
}
