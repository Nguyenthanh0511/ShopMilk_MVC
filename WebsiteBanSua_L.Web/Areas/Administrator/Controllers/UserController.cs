using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using Service.IService;

namespace WebsiteBanSua_L.Web.Areas.Administrator.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {

            //var categories = await _service.GetAll();
            var user = await _service.GetAll();
            return View(user);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Users user)
        {
                _service.Create(user);
                if (_service.Flag)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return BadRequest(_service.Error);
                }
            return View(user);
        }
        

    }
}

