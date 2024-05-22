using JobLandin.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using JobLandin.Application.Common.Interfaces;
using JobLandin.Domain.Entities;

namespace JobLandin.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IJobRepository _jobRepository;

        public HomeController(ILogger<HomeController> logger, IJobRepository jobRepository)
        {
            _logger = logger;
            _jobRepository = jobRepository;
        }

        public IActionResult Index(string searchString)
        {
            _logger.LogInformation($"Search string received: {searchString}");
            var jobs = string.IsNullOrEmpty(searchString) 
                ? new List<Job>() 
                : _jobRepository.SearchJobs(searchString);
            _logger.LogInformation($"Number of jobs retrieved: {jobs.Count()}");
            return View(jobs);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
