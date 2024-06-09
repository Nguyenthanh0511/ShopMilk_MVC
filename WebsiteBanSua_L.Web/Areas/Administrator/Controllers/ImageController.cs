using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using Service.IService;

namespace WebsiteBanSua_L.Web.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class ImageController : Controller
    {
        private readonly IImageService _service;
        public ImageController(IImageService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {

            //var categories = await _service.GetAll();
            var image = await _service.GetAll();
            return View(image);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Image image)
        {
            if (ModelState.IsValid)
            {
                _service.Create(image);
                if (_service.Flag)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return BadRequest(_service.Error);
                }

            }
            return View(image);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest("Id is empty");
            }

            var image = await _service.Get(id);
            if (image == null)
            {
                return NotFound();
            }
            return View(image);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id == 0)
            {
                return BadRequest("Id is empty");
            }

            await _service.Delete(id);

            if (_service.Flag)
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", _service.Error);
            var category = await _service.Get(id);
            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            if (id == 0)
            {
                return BadRequest("Id is empty");
            }

            var category = await _service.Get(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Image image)
        {
            if (image == null)
            {
                return BadRequest("Entity is empty");
            }
                await _service.Update(image);

                if (_service.Flag)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", _service.Error);
                }

            return View(image);
        }
    }
}
