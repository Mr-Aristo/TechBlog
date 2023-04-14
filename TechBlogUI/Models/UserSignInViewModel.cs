using System.ComponentModel.DataAnnotations;


namespace TechBlogUI.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage = "Please enter username ")]
        public string username { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        public string password { get; set; }
    }
}
