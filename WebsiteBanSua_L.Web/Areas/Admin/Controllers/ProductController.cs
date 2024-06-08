using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using Service.IService;

namespace WebsiteBanSua_L.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _service.GetAll();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                await _service.Create(product);
                if (_service.Flag)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", _service.Error);
                }
            }
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Id is empty");
            }
            var product = await _service.Get(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Id is empty");
            }
            await _service.Delete(id);
            if (_service.Flag)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", _service.Error);
            var product = await _service.Get(id);
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Id is empty");
            }
            var product = await _service.Get(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Product product)
        {
            if (product == null)
            {
                return BadRequest("Entity is empty");
            }
            if (ModelState.IsValid)
            {
                await _service.Update(product);
                if (_service.Flag)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", _service.Error);
            }
            return View(product);
        }
    }
}
