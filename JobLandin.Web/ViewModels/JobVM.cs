using JobLandin.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JobLandin.Web.ViewModels
{
    public class JobVM
    {
        public Job? Job { get; set; }

        public IEnumerable<SelectListItem> JobList { get; set; }
    }
}
