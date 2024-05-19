using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JobLandin.Domain.Entities
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }
        public string? Industry { get; set; }
        public int? Size { get; set; }
        public string? Description { get; set; }
        public string? Website { get; set; }
        //public byte[]? Logo { get; set; }


        [NotMapped]
        public IFormFile? Image { get; set; }


        [Display(Name = "Logo Url")]
        public string? LogoUrl { get; set; }



        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
