using System.ComponentModel.DataAnnotations.Schema;

namespace JobLandin.Domain.Entities
{

    public enum ApplicationType
    {
        Link,
        Email,
        Phone
    }

    public class Job
    {
        public int Id { get; set; }


        [ForeignKey("Company")]
        public int CompanyId { get; set; }


        [ValidateNever]
        public Company Company { get; set; } = null!;


        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public decimal? Salary { get; set; }

        //ADD A LINK OR CONTACT FOR JOB APPLICATION
        public ApplicationType ApplicationMethod { get; set; }
        public string ApplicationDetails { get; set; }

        public DateTime? CreatedAt { get; set; }
        
    }
}
