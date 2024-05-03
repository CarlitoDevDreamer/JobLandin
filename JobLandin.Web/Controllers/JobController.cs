using JobLandin.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using JobLandin.Domain.Entities;

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



        //GET: Job/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Job/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Job job)
        {
            if (ModelState.IsValid)
            {
                _db.Jobs.Add(job);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(job);
        }



    }
}
