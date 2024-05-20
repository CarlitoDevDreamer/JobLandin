namespace JobLandin.Domain.Entities;

public class Candidate
{
    public int CandidateId { get; set; }
    public string CandidateName { get; set; }
    public string Location { get; set; }
    public string? Industry { get; set; }
    
    public string? UserId { get; set; }
    public ApplicationUser? User { get; set; }
}