namespace JobLandin.Domain.Entities
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }
        public string Industry { get; set; }
        public int Size { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
        public byte[]? Logo { get; set; }
    }
}
