using System.ComponentModel.DataAnnotations;

namespace TechBlogAPI.DAL
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        public string? Name { get; set; }
    }
}
