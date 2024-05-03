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


        //GET
        public IActionResult Update(int jobId)
        {
            Job? obj = _db.Jobs.FirstOrDefault(u => u.Id == jobId);


            if (obj is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(obj);
        }


        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Job obj)
        {
            if (ModelState.IsValid && obj.Id > 0)
            {
                _db.Jobs.Update(obj);
                _db.SaveChanges();
                
                //return RedirectToAction("Index"); //Magic Strings
                return RedirectToAction(nameof(Index));
            }
            
            return View(obj);

        }



        //GET DELETE
        public IActionResult Delete(int jobId)
        {
            Job? obj = _db.Jobs.FirstOrDefault(u => u.Id == jobId);


            if (obj is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(obj);
        }





        //POST DELETE
        [HttpPost]

        public IActionResult Delete(Job obj)
        {
            Job? objFromDb = _db.Jobs.FirstOrDefault(u => u.Id == obj.Id);

            if (objFromDb is not null)
            {
                _db.Jobs.Remove(objFromDb);
                _db.SaveChanges();
                //return RedirectToAction("Index"); //Magic Strings
                return RedirectToAction(nameof(Index));
            }

            return View(obj);

        }





    }
}
