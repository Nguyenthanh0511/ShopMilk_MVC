using Microsoft.AspNetCore.Mvc;
using Service.Base;
using WebsiteBanSua_L.Reponsive.Base;

namespace WebsiteBanSua_L.Web.Areas.Admin.Controllers.Base
{
    public class BaseController<T, TService> : Controller where T:class, new() where TService : IBaseService<T>
    {
        public readonly TService _service;
        public BaseController(TService service)
        {
            _service = service;
        }
    }
}
