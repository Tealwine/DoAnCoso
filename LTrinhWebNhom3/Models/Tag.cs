using System.ComponentModel.DataAnnotations;

namespace LTrinhWebNhom3.Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        public string TagName { get; set; }
        public string Description { get; set; }
        public List<Portfolio>? portfolios { get; set; }
    }
}
