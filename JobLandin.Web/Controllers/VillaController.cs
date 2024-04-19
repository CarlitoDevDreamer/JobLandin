using JobLandin.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace JobLandin.Web.Controllers
{
    public class JobController : Controller
    {
        private readonly ApplicationDbContext _db;

        public JobController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var jobs = _db.Jobs.ToList();
            return View(jobs);
        }
    }
}
