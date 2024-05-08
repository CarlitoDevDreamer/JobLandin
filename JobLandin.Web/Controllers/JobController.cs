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
            
  /* Para imprimir os erros de validação          
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .Select(x => new { x.Key, x.Value.Errors })
                    .ToArray();

                foreach (var error in errors)
                {
                    foreach (var subError in error.Errors)
                    {
                        Console.WriteLine($"Key: {error.Key}, Error: {subError.ErrorMessage}");
                    }
                }
            }
*/
            if (ModelState.IsValid)
            {
                _db.Jobs.Add(obj.Job);
                _db.SaveChanges();
                TempData["success"] = "The Job Offer has been created successfully.";
                return RedirectToAction(nameof(Index));
            }
            
            obj.CompanyList = _db.Companies.ToList().Select(u => new SelectListItem
            {
                Text = u.CompanyName,
                Value = u.CompanyId.ToString()
            });

            return View(obj);
        }


        //GET
        public IActionResult Update(int jobId)
        {
            JobVM jobVM = new()
            {
                CompanyList = _db.Companies.ToList().Select(u => new SelectListItem
                {
                    Text = u.CompanyName,
                    Value = u.CompanyId.ToString()
                }),
                Job = _db.Jobs.FirstOrDefault(u => u.Id == jobId)
            };

            if (jobVM.Job is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(jobVM);
        }


        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(JobVM jobVM)
        {

            if (ModelState.IsValid)
            {
                _db.Jobs.Update(jobVM.Job);
                _db.SaveChanges();
                TempData["success"] = "The Job Offer has been updated successfully.";
                return RedirectToAction(nameof(Index));
            }




            jobVM.CompanyList = _db.Companies.ToList().Select(u => new SelectListItem
            {
                Text = u.CompanyName,
                Value = u.CompanyId.ToString()
            });


            return View(jobVM);

        }



        //GET DELETE
        //GET
        public IActionResult Delete(int jobId)
        {
            JobVM jobVM = new()
            {
                CompanyList = _db.Companies.ToList().Select(u => new SelectListItem
                {
                    Text = u.CompanyName,
                    Value = u.CompanyId.ToString()
                }),
                Job = _db.Jobs.FirstOrDefault(u => u.Id == jobId)
            };

            if (jobVM.Job is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(jobVM);
        }




        //POST DELETE
        //POST DELETE
        [HttpPost]
        public IActionResult Delete(JobVM jobVM)
        {
            Company? objFromDb = _db.Companies
                .FirstOrDefault(_ => _.CompanyId == jobVM.Job.Id);

            if (objFromDb is not null)
            {
                _db.Companies.Remove(objFromDb);
                _db.SaveChanges();

                TempData["success"] = "The Job Offer has been deleted successfully.";

                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = "The Job Offer could not be deleted.";
            return View(jobVM);
        }






    }
}
