using Microsoft.AspNetCore.Mvc;
using Service.IService;

namespace WebsiteBanSua_L.Web.Controllers
{
    public class OtherPageController : Controller
    {
        private readonly IImageService _service;
        public OtherPageController(IImageService service)
        {
            _service = service;
        }

        public IActionResult OurTeam()
        {
            return View();
        }
        public async Task<IActionResult> Gallery()
        {
            var gallery = await _service.GetAll();
            return View(gallery);
        }
    }
}
