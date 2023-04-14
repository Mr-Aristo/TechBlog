using TechBlogUI.Models;
using DocumentFormat.OpenXml.Office.CustomUI;
using Microsoft.AspNetCore.Mvc;
using Nest;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TechBlogUI.Controllers
{
    public class EmployeeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7135/api/Default");//url in gelecegi kisim.Response verecek olan url
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<EmployeeTest>>(jsonString);
            return View(values);

        }

        [HttpGet]
        public IActionResult AddEmployee()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeTest e)
        {
            var httpClient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(e);
            StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");//parametreler: ilk contentin icerigi,Encoding turu,media type(apilerle acilisiyoruz)
            var responseMessage = await httpClient.PostAsync("https://localhost:7135/api/Default/EmployeeAdd/", content);//yukarida get burada post. Veri gondercegiz.conten aldigi deger. adresimize gonderecek
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }


            return View(e);
        }

        [HttpGet]
        public async Task<IActionResult> EditEmployee(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7135/api/Default/EmployeeUpdate/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonEmployee = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<EmployeeTest>(jsonEmployee);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditEmployee(EmployeeTest e)
        {
            var httpClient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(e);
            var content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PutAsync("https://localhost:7135/api/Default/EmployeeUpdate/", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.DeleteAsync("https://localhost:7135/api/Default/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }
    }
}
