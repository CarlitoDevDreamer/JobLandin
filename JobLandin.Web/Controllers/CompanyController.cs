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

}

}