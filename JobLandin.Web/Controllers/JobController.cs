using JobLandin.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using JobLandin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using JobLandin.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using JobLandin.Application.Common.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace JobLandin.Web.Controllers
{
    public class JobController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;

        private readonly ILogger<JobController> _logger;

        public JobController(IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager,
            ILogger<JobController> logger)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var jobs = _unitOfWork.Job.GetAll(includeProperties: "Company");

            if (User.IsInRole(SD.Role_Company))
            {
                var userId = _userManager.GetUserId(User);
                var company = await _unitOfWork.Company.GetFirstOrDefaultAsync(c => c.UserId == userId);
                if (company != null)
                {
                    ViewBag.CompanyId = company.CompanyId;
                }
            }

            return View(jobs);
        }


        //GET: Job/Create
        [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Company)]
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
        [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Company)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(JobVM obj)
        {
            if (User.IsInRole(SD.Role_Company))
            {
                var userId = _userManager.GetUserId(User);
                _logger.LogInformation($"User ID: {userId}");

                var company = await _unitOfWork.Company.GetFirstOrDefaultAsync(c => c.UserId == userId);
                _logger.LogInformation($"Company: {company}");

                if (company == null)
                {
                    return NotFound("Company not found for the current user.");
                }

                if (ModelState.IsValid)
                {
                    obj.Job.CompanyId = company.CompanyId;
                    _unitOfWork.Job.Add(obj.Job);
                    _unitOfWork.Save();
                    TempData["success"] = "The Job Offer has been created successfully.";
                    return RedirectToAction(nameof(Index));
                }
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.Job.Add(obj.Job);
                _unitOfWork.Save();
                TempData["success"] = "The Job Offer has been created successfully.";
                return RedirectToAction(nameof(Index));
            }

            _logger.LogInformation(
                $"Model state is not valid. Errors: {string.Join(", ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage))}");

            obj.CompanyList = _unitOfWork.Company.GetAll().Select(u => new SelectListItem
            {
                Text = u.CompanyName,
                Value = u.CompanyId.ToString()
            });

            return View(obj);
        }


        //GET UPDATE

//GET
        [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Company)]
        public async Task<IActionResult> Update(int jobId)
        {
            var job = _unitOfWork.Job.Get(u => u.Id == jobId);
            if (job == null)
            {
                return RedirectToAction("Error", "Home");
            }

            if (User.IsInRole(SD.Role_Company))
            {
                var userId = _userManager.GetUserId(User);
                var company = await _unitOfWork.Company.GetFirstOrDefaultAsync(c => c.UserId == userId);
                if (company == null || job.CompanyId != company.CompanyId)
                    if (!User.IsInRole(SD.Role_Admin))
                    {
                        {
                            return Forbid(); // or any other action you want to take
                        }
                    }
            }

            JobVM jobVm = new()
            {
                CompanyList = _unitOfWork.Company.GetAll().Select(u => new SelectListItem
                {
                    Text = u.CompanyName,
                    Value = u.CompanyId.ToString()
                }),
                Job = job
            };

            return View(jobVm);
        }


        //POST UPDATE
        [HttpPost]
        [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Company)]
        [ValidateAntiForgeryToken]
        public IActionResult Update(JobVM jobVM)
        {
            if (ModelState.IsValid)
            {
                // Ensure that the Job's Id is set correctly
                if (jobVM.Job.Id <= 0)
                {
                    TempData["error"] = "Invalid Job Id.";
                    return View(jobVM);
                }

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
        [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Company)]
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
        [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Company)]
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