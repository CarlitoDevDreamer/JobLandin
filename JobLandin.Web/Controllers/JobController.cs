using JobLandin.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using JobLandin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using JobLandin.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using JobLandin.Application.Common.Interfaces;

namespace JobLandin.Web.Controllers
{
    public class JobController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public JobController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {

            var jobs = _unitOfWork.Job.GetAll(includeProperties: "Company");

            return View(jobs);
        }



        //GET: Job/Create
        public IActionResult Create()
        {
            JobVM jobVM = new()
            {
                CompanyList = _unitOfWork.Company.GetAll().Select(u => new SelectListItem
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
            

            if (ModelState.IsValid)
            {
                _unitOfWork.Job.Add(obj.Job);
                _unitOfWork.Save();
                TempData["success"] = "The Job Offer has been created successfully.";
                return RedirectToAction(nameof(Index));
            }
            
            obj.CompanyList = _unitOfWork.Company.GetAll().Select(u => new SelectListItem
            {
                Text = u.CompanyName,
                Value = u.CompanyId.ToString()
            });

            return View(obj);
        }


        //GET UPDATE

        //GET
        public IActionResult Update(int jobId)
        {
            JobVM jobVm = new()
            {
                CompanyList = _unitOfWork.Company.GetAll().Select(u => new SelectListItem
                {
                    Text = u.CompanyName,
                    Value = u.CompanyId.ToString()
                }),
                Job = _unitOfWork.Job.Get(u => u.Id == jobId)
            };

            if (jobVm.Job is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(jobVm);
        }



        //POST UPDATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(JobVM jobVM)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Job.Update(jobVM.Job);
                _unitOfWork.Save();
                TempData["success"] = "The Job Offer has been updated successfully.";
                return RedirectToAction(nameof(Index));
            }




            jobVM.CompanyList = _unitOfWork.Company.GetAll().Select(u => new SelectListItem
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
                CompanyList = _unitOfWork.Company.GetAll().Select(u => new SelectListItem
                {
                    Text = u.CompanyName,
                    Value = u.CompanyId.ToString()
                }),
                Job = _unitOfWork.Job.Get(u => u.Id == jobId)
            };

            if (jobVM.Job is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(jobVM);
        }




        //POST DELETE
        [HttpPost]
        public IActionResult Delete(JobVM jobVm)
        {
            Job? objFromDb = _unitOfWork.Job.Get(_ => _.Id == jobVm.Job.Id);

            if (objFromDb is not null)
            {
                _unitOfWork.Job.Remove(objFromDb);
                _unitOfWork.Save();

                TempData["success"] = "The Job Offer has been deleted successfully.";

                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = "The Job Offer could not be deleted.";
            return View(jobVm);
        }







    }
}
