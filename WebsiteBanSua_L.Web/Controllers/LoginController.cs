using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Model.Entities;
using Service.IService;

namespace WebsiteBanSua_L.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult SignIn()
        {
            return View();
        }
        //0: là không thành công, 1: Là User, 2 là Admin
        [HttpPost]
        public async Task<IActionResult> SignIn(string username, string password)
        {
            Users user= await _userService.SignIn(username,password);
            if(user == null )
            {
                return BadRequest("Username or Password isn't success");
            }
            else if(user != null)
            {
                return Json(new {UserId = user.Id});
            }
            else if(user.role == "User")
            {
                return RedirectToAction("Index", "Home");
            }
            else if(user.role == "Admin")
            {
                return RedirectToAction("Index", "Category", new { area = "Administrator" });
            }

            return BadRequest("Unknown");
        }
        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Users user)
        {
            var listUser = await _userService.GetAll();
            var existingUser = listUser.FirstOrDefault(u => u.UserName == user.UserName);

            if (existingUser == null)
            {
                _userService.Create(user);
                if (_userService.Flag)
                {
                    return RedirectToAction("Index", "Home"); // Redirect to Home/Index
                }
                else
                {
                    return BadRequest(_userService.Error); // Return BadRequest with error message
                }
            }
            else
            {
                ModelState.AddModelError("UserName", "Username already exists"); // AddModelError for username already exists
            }

            return View(user); // Return the view with the model (user) to display validation errors
        }
    }
}
