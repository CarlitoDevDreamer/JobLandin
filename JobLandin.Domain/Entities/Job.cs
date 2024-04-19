namespace JobLandin.Domain.Entities
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public decimal? Salary { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
