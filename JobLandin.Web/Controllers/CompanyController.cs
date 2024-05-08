using JobLandin.Domain.Entities;
using JobLandin.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobLandin.Web.Controllers
{

public class CompanyController : Controller
{
    private readonly ApplicationDbContext _db;

    public CompanyController(ApplicationDbContext db)
    {
        _db = db;
    }
    public IActionResult Index()
    {
        var companies = _db.Companies.ToList();
        return View(companies);
    }

    
    
    
    
    //GET
    public IActionResult Create()
    {
        return View();
    }

//POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Company obj)
    {
       
        if (ModelState.IsValid)
        {
            _db.Companies.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "Company Created Successfully";
            //return RedirectToAction("Index"); //Magic Strings
            return RedirectToAction(nameof(Index));
        }
        TempData["erros"] = "Company Not Created";
        return View(obj);

    }
    
    
    
    
    //GET
    public IActionResult Update(int companyId)
    {
        Company? obj = _db.Companies.FirstOrDefault(u => u.CompanyId == companyId);

        //Villa? obj2 = _db.Villas.Find(villaId);

        //var VillaList = _db.Villas.Where(u => u.Price > 50 && u.Occupancy > 0).FirstOrDefault();

        if (obj is null) {
            return RedirectToAction("Error", "Home");
        }
        return View(obj);
    }


//POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Update(Company obj)
    {
        if (ModelState.IsValid && obj.CompanyId > 0)
        {
            _db.Companies.Update(obj);
            _db.SaveChanges();
            TempData["success"] = "Company Updated Successfully";
            //return RedirectToAction("Index"); //Magic Strings
            return RedirectToAction(nameof(Index));
        }
        TempData["erros"] = "Company Not Updated";
        return View(obj);

    }

    
    
    
    
    
    
    
    
    
}

}