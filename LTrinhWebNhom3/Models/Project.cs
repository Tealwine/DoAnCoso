using System.ComponentModel.DataAnnotations;

namespace LTrinhWebNhom3.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ProjectImageUrl { get; set; }
        public string ProjectUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public List<ProjectImage> Images { get; set; }
        public List<Portfolio> portfolios { get; set; }

    }
    
}
