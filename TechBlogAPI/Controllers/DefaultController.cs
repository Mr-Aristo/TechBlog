using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechBlogAPI.DAL;

namespace TechBlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        // [HttpGet("Test")] Birden fazla get oldugunde yada parametre gonderecegimizde bu sekil bir yapi kullaniriz.
        [HttpGet]
        public IActionResult EmployeeList()
        {
            using var c = new ContextDb();
            var values = c.Employees.ToList();

            return Ok(values); // Api de mvc deki gibi view donmez. Ok() 200 codeu sistem basarili oldugunda donecek olan kod.


        }

        [HttpPost("EmployeeAdd")]
        public IActionResult EmployeeAdd(Employee employee)
        {
            using var c = new ContextDb();

            c.Employees.Add(employee);
            c.SaveChanges();

            return Ok();


        }

        [HttpGet("{id}")]//parametere alma.
        public IActionResult EmployeeGetById(int id)
        {
            using var c = new ContextDb();
            var emp = c.Employees.Find(id);

            if (emp == null)
                return NotFound();
            else
                return Ok(emp);

        }

        [HttpDelete("{id}")]
        public IActionResult EmployeeDelete(int id)
        {
            using var c = new ContextDb();
            var emp = c.Employees.Find(id);
            if (emp == null)
            { return NotFound(); }
            else
            {
                c.Remove(emp);
                c.SaveChanges();
                return Ok();
            }

        }

        [HttpPut("EmployeeUpdate")]
        public IActionResult EmployeeUpdate(Employee employee)
        {
            using var c = new ContextDb();
            var emp = c.Find<Employee>(employee.ID);//Find<T> degeri gondermezsek employee.ID yi alamayiz
            if(emp== null)
            {
                return NotFound();
            }
            else
            {
                emp.Name= employee.Name;
                c.Employees.Update(emp);
                c.SaveChanges();
                return Ok();
            }


        }
    }
}
