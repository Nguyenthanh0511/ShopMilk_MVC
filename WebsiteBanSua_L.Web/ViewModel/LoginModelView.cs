using System.ComponentModel.DataAnnotations;

namespace WebsiteBanSua_L.Web.ViewModel
{
    public class LoginModelView
    {
        [Required(ErrorMessage = "Please enter your username.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter your password.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
