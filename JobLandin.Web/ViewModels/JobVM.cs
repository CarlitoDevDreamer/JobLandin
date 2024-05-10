using JobLandin.Domain.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JobLandin.Web.ViewModels
{
    public class JobVM
    {
        public Job Job { get; set; } = null!;


        [ValidateNever]
        public IEnumerable<SelectListItem> CompanyList { get; set; }
    }
}
