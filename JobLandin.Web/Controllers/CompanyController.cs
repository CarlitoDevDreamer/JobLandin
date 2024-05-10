using JobLandin.Application.Common.Interfaces;
using JobLandin.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace JobLandin.Web.Controllers
{

    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var companies = _unitOfWork.Company.GetAll();
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
                _unitOfWork.Company.Add(obj);
                _unitOfWork.Save();
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
            Company? obj = _unitOfWork.Company.Get(u => u.CompanyId == companyId);

            //Villa? obj2 = _db.Villas.Find(villaId);

            //var VillaList = _db.Villas.Where(u => u.Price > 50 && u.Occupancy > 0).FirstOrDefault();

            if (obj is null)
            {
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
                _unitOfWork.Company.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Company Updated Successfully";
                //return RedirectToAction("Index"); //Magic Strings
                return RedirectToAction(nameof(Index));
            }
            TempData["erros"] = "Company Not Updated";
            return View(obj);

        }







        //GET DELETE
        public IActionResult Delete(int companyId)
        {
            Company? obj = _unitOfWork.Company.Get(u => u.CompanyId == companyId);

            //Villa? obj2 = _db.Villas.Find(villaId);

            //var VillaList = _db.Villas.Where(u => u.Price > 50 && u.Occupancy > 0).FirstOrDefault();

            if (obj is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(obj);
        }





        //POST DELETE
        [HttpPost]

        public IActionResult Delete(Company obj)
        {
            Company? objFromDb = _unitOfWork.Company.Get(u => u.CompanyId == obj.CompanyId);

            if (objFromDb is not null)
            {
                _unitOfWork.Company.Remove(objFromDb);
                _unitOfWork.Save();
                TempData["success"] = "Villa Deleted Successfully";
                //return RedirectToAction("Index"); //Magic Strings
                return RedirectToAction(nameof(Index));
            }

            TempData["erros"] = "Villa Not Deleted";
            return View(obj);

        }







    }

}