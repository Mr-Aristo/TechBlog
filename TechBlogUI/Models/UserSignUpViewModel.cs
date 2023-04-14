using System.ComponentModel.DataAnnotations;

//Bu model identity kontrolu icin olusturuldu.
namespace TechBlogUI.Models
{
    public class UserSignUpViewModel
    {
        //Required kismini viewde span ile cektik. asp-validation-for icinde displayi tanimladik ve span
        // otomatik olarak cekti.
        [Display(Name = "Name Surname")]
        [Required(ErrorMessage = "Please enter name and surname")]
        public string NameSurname { get; set; }


        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; }


        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password isn't the same !")]
        public string ConfirmPassword { get; set; }


        [Display(Name = "Mail")]
        [Required(ErrorMessage = "Please enter mail ")]
        public string Mail { get; set; }


        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Please enter user name")]
        public string UserName { get; set; }

        public bool IsAcceptTheContract { get; set; }

    }
}
