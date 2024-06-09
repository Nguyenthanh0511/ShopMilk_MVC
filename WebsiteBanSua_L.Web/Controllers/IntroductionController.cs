using Microsoft.AspNetCore.Mvc;
using Service.IService;

namespace WebsiteBanSua_L.Web.Controllers
{
    public class IntroductionController : Controller
    {
        private readonly IProductService _productService;
        public IntroductionController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var product = await _productService.GetAll();
            return View(product);
        }
    }
}
