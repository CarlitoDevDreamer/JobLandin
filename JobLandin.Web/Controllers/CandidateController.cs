using JobLandin.Application.Common.Interfaces;
using JobLandin.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobLandin.Web.Controllers
{
    public class CandidateController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CandidateController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var candidates = _unitOfWork.Candidate.GetAll();
            return View(candidates);
        }



        //GET
        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [Authorize(Roles = SD.Role_Admin)]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Candidate obj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //ProfilePic File Upload
                    if (obj.Image != null)
                    {
                        Console.WriteLine("ProfilePic Image is not null, proceeding with file upload."); // Logging

                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(obj.Image.FileName);
                        string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, @"images\CandidateProfilePics");
                        using var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create);
                        obj.Image.CopyTo(fileStream);

                        obj.ProfilePicUrl = @"\images\CandidateProfilePics\" + fileName;
                    }
                    else
                    {
                        Console.WriteLine("ProfilePic Image is null, using default ProfilePic logo URL."); // Logging
                        obj.ProfilePicUrl = "https://placehold.co/50x50";
                    }

                    _unitOfWork.Candidate.Add(obj);
                    _unitOfWork.Save();
                    TempData["success"] = "Candidate Created Successfully";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Log the exception here
                    Console.WriteLine("Error while creating Candidate: " + ex.Message); // Logging
                    TempData["errors"] = "Error while creating Candidate: " + ex.Message;
                }
            }
            TempData["errors"] = "Candidate Not Created";
            return View(obj);
        }




        //GET
        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult Update(int candidateId)
        {
            Candidate? obj = _unitOfWork.Candidate.Get(u => u.CandidateId == candidateId);

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
        [Authorize(Roles = SD.Role_Admin)]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Candidate obj)
        {
            if (ModelState.IsValid && obj.CandidateId > 0)
            {
                //Logo File Upload
                if (obj.Image != null)
                {
                    Console.WriteLine("ProfilePic Image is not null, proceeding with file upload."); // Logging

                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(obj.Image.FileName);
                    string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, @"images\CandidateProfilePics");
                    using var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create);
                    obj.Image.CopyTo(fileStream);

                    obj.ProfilePicUrl = @"\images\CandidateProfilePics\" + fileName;
                }
                else
                {
                    Console.WriteLine("ProfilePic Image is null, using existing ProfilePic URL."); // Logging
                }

                _unitOfWork.Candidate.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Candidate Updated Successfully";
                return RedirectToAction(nameof(Index));
            }
            TempData["errors"] = "Candidate Not Updated";
            return View(obj);
        }







        //GET DELETE
        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult Delete(int candidateId)
        {
            Candidate? obj = _unitOfWork.Candidate.Get(u => u.CandidateId == candidateId);

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
        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult Delete(Candidate obj)
        {
            Candidate? objFromDb = _unitOfWork.Candidate.Get(u => u.CandidateId == obj.CandidateId);

            if (objFromDb is not null)
            {
                _unitOfWork.Candidate.Remove(objFromDb);
                _unitOfWork.Save();
                TempData["success"] = "Candidate Deleted Successfully";
                //return RedirectToAction("Index"); //Magic Strings
                return RedirectToAction(nameof(Index));
            }

            TempData["erros"] = "Candidate Not Deleted";
            return View(obj);

        }







    }
 
}