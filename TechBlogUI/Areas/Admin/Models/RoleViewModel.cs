using System.ComponentModel.DataAnnotations;

namespace TechBlogUI.Areas.Admin.Models
{
    //Model ile yapilan islemler genelde mimarinin disina cikildiginda yapilirbilir. 
    public class RoleViewModel
    {
        [Required(ErrorMessage = "Please enter role name !s")]
        public string Name { get; set; }
    }
}
