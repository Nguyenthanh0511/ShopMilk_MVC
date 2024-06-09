using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using Service.IService;

namespace WebsiteBanSua_L.Web.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;
        //private readonly ICategoryRepo _repo;
        public CategoryController(ICategoryService service)
        {
            _service = service ?? throw new ArgumentNullException();
        }

        public async Task<IActionResult> Index()
        {

            //var categories = await _service.GetAll();
            var categories = await _service.GetAll();
            return View(categories);
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
                _service.Create(category);
                if (_service.Flag)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return BadRequest(_service.Error);
                }

            }
            return View(category);
        }
       
        //public async Task<IActionResult> Create(Category category)
        //{
        //    if (category != null)
        //    {// Category với name null, đúng rồi không lấy từ form được, bỏ đấy đi cũng được, nó chỉ là bind giống kiểu validation ý
        //        var entity = new Category
        //        {
        //            Name = category.Name,
        //        };
        //        // Chưa có
        //        await _service.Create(entity);

        //        if (_service.Flag)
        //        {
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", _service.Error);
        //        }
        //    }
        //    return View(category);
        //}


        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create(Category category)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var entity = new Category
        //        {
        //            Id = Guid.NewGuid().ToString().Substring(0,12),
        //            Name = category.Name,
        //        };

        //        await _service.Create(entity);

        //        if (_service.Flag)
        //        {
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", _service.Error);
        //        }
        //    }

        //    // Model state is invalid or service.Flag is false, return the Create view with validation errors
        //    return View(category);
        //}

        //[HttpGet]
        //public async Task<IActionResult> Delete(string id)
        //{
        //    if (string.IsNullOrEmpty(id))
        //    {
        //        return BadRequest("Id is empty");
        //    }

        //    var category = await _service.Get(id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(category);
        //}

        //[HttpPost, ActionName("Delete")]
        //public async Task<IActionResult> DeleteConfirmed(string id)
        //{
        //    if (string.IsNullOrEmpty(id))
        //    {
        //        return BadRequest("Id is empty");
        //    }

        //    await _service.Delete(id);

        //    if (_service.Flag)
        //    {
        //        return RedirectToAction("Index");
        //    }

        //    ModelState.AddModelError("", _service.Error);
        //    var category = await _service.Get(id);
        //    return View(category);
        //}

        //[HttpGet]
        //public async Task<IActionResult> Update(string id)
        //{
        //    if (string.IsNullOrEmpty(id))
        //    {
        //        return BadRequest("Id is empty");
        //    }

        //    var category = await _service.Get(id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(category);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Update(Category category)
        //{
        //    if (category == null)
        //    {
        //        return BadRequest("Entity is empty");
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        await _service.Update(category);

        //        if (_service.Flag)
        //        {
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", _service.Error);
        //        }
        //    }

        //    return View(category);
        //}
    }
}
