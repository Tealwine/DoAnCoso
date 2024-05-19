namespace LTrinhWebNhom3.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ProjectImageUrl { get; set; }
        public string ProjectUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public List<ProjectImage> Images { get; set; }
        public Portfolio Portfolios { get; set; }

    }
    public class ProjectImage
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
