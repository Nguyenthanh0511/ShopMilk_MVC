using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using Service.IService;

namespace WebsiteBanSua_L.Web.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class CartDetailController : Controller
    {
        private ICartDetailService _service;
        public CartDetailController(ICartDetailService service) {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {

            //var categories = await _service.GetAll();
            var cartD = await _service.GetAll();
            return View(cartD);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CartDetail cartdetail)
        {
                _service.Create(cartdetail);
                if (_service.Flag)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return BadRequest(_service.Error);
                }
            return View(cartdetail);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            //Lay id
            if(id== 0)
            {
                return BadRequest("Id null");
            }
            var cardetail = _service.Get(id);
            if(_service.Flag)
            {
                return View(cardetail);
            }
            else
            {
                return BadRequest(_service.Error);
            }
        }

        [HttpPost]
        public IActionResult DeleteComfirm(int id) // Sua o form nhap
        {
            _service.Delete(id);
            if (_service.Flag)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return BadRequest(_service.Error);
            }
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            if(id == 0)
            {
                return NotFound("Not id");
            }
            _service.Get(id);
            if (_service.Flag)
            {
                return View();
            }
            else
            {
                return BadRequest(_service.Error);
            }
        }
        [HttpPost]
        public IActionResult Update(CartDetail cartdetail)
        {
            if(ModelState.IsValid)
            {
                _service.Update(cartdetail);
                if (_service.Flag)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return BadRequest(_service.Error);
                }
            }
            return View(cartdetail);
        }
    }
}
