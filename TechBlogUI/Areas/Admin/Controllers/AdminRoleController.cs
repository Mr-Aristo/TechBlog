using DocumentFormat.OpenXml.Office2010.ExcelAc;
using DocumentFormat.OpenXml.Presentation;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechBlogUI.Areas.Admin.Models;

namespace TechBlogUI.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminRoleController : Controller
{
    private readonly RoleManager<AppRole> _roles; // rolemanager using Microsoft.AspNetCore.Identity in bir parcasi

    public AdminRoleController(RoleManager<AppRole> roles, UserManager<AppUser> userManager)
    {
        _roles = roles;
        _userManager = userManager;
    }

    private readonly UserManager<AppUser> _userManager;


    public IActionResult Index()
    {
        var values = _roles.Roles.ToList();

        return View(values);
    }

    [HttpGet]
    public IActionResult AddRole()
    {
        var values = _roles.Roles.ToList();

        return View(values);
    }

    [HttpPost]
    public async Task<IActionResult> AddRole(RoleViewModel r)
    {
        //Burada model uzerinden veriyi girdik ve entiy classina gondererek veriyi db ye kayit ettik. 
        if (ModelState.IsValid)
        {
            AppRole role = new AppRole
            {
                Name = r.Name
            };

            var result = await _roles.CreateAsync(role);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }

        }

        return View(r);
    }

    [HttpGet]
    public IActionResult UpdateRole(int id)
    {
        var values = _roles.Roles.FirstOrDefault(x => x.Id == id); //parametre olarak gelen id ye esit olan degeri getirdik.

        RoleUpdateViewModel roleModel = new RoleUpdateViewModel
        {
            ID = values.Id,
            Name = values.Name,
        };

        return View(roleModel);


    }

    [HttpPost]
    public async Task<IActionResult> UpdateRole(RoleUpdateViewModel model)
    {
        var values = _roles.Roles.Where(x => x.Id == model.ID).FirstOrDefault();

        values.Name = model.Name;
        var res = await _roles.UpdateAsync(values);
        if (res.Succeeded)
        {
            return RedirectToAction("Index");
        }

        return View(model);

    }


    public async Task<IActionResult> DeleteRole(int id)
    {
        //Mimarinin disinda bir islem yapdigimiz icind silme ve guncelleme islemleri 
        //asenkron olarak yapildi. Identity ile bu tur crud islemleri yapilabiliyor.
        var values = _roles.Roles.FirstOrDefault(x => x.Id == id);
        var res = await _roles.DeleteAsync(values);

        if (res.Succeeded)
        {
            return RedirectToAction("Index");

        }

        return View();
    }

    public IActionResult UserRoleList()
    {
        var values = _userManager.Users.ToList();
        return View(values);

    }

    [HttpGet]
    public async Task<IActionResult> AssignRole(int id)
    {
        var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
        var roles = _roles.Roles.ToList();

       TempData["Userid"] = user.Id; //TempData is used to transfer data from view to controller
                                      //, controller to view, or from one action method to another
                                      //action method of the same or a different controller. 
                                      //Like Viewbag

        var userRoles = await _userManager.GetRolesAsync(user);

        List<RoleAssignViewModel> model = new List<RoleAssignViewModel>();
        foreach (var item in roles)
        {
            RoleAssignViewModel m = new RoleAssignViewModel();

            m.RoleId = item.Id;
            m.Name = item.Name;
            m.Exist = userRoles.Contains(item.Name);//Bu kullanicinin sahip holdugu rollri tru false olarak cevirecekl
            model.Add(m);

        }


        return View(model);


    }

}
