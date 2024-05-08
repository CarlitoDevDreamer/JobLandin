using JobLandin.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using JobLandin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using JobLandin.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            
            var jobs = _db.Jobs
                .Include(u => u.Company)
                .ToList();

            return View(jobs);
        }



        //GET: Job/Create
        public IActionResult Create()
        {
            JobVM jobVM = new()
            {
                CompanyList = _db.Companies.ToList().Select(u => new SelectListItem
                {
                    Text = u.CompanyName,
                    Value = u.CompanyId.ToString()
                })
            };

            return View(jobVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(JobVM obj)
        {

            bool jobExists = _db.Jobs.Any(u => u.Id == obj.VillaNumber.Villa_Number);

            //ModelState.Remove("Villa"); equivalente ao ValidateNever
            if (ModelState.IsValid && !roomNumberExists)
            {




                _db.VillaNumbers.Add(obj.VillaNumber);
                _db.SaveChanges();
                TempData["success"] = "The villa number has been created successfully.";
                return RedirectToAction(nameof(Index));
            }

            if (roomNumberExists)
            {
                TempData["error"] = "The villa already exists.";
            }


            obj.VillaList = _db.Villas.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });


            return View(obj);
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
