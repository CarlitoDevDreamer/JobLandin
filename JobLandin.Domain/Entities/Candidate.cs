using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace JobLandin.Domain.Entities;

public class Candidate
{
    public int CandidateId { get; set; }
    public string CandidateName { get; set; }
    public string Location { get; set; }
    public string? Industry { get; set; }


    [NotMapped] public IFormFile? Image { get; set; }


    [Display(Name = "ProfilePic Url")] public string? ProfilePicUrl { get; set; }


    public string? ContactInfo { get; set; }


    public string? UserId { get; set; }
    public ApplicationUser? User { get; set; }
}