using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LTrinhWebNhom3.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }
        public DateTime? CreateOn { get; set; }

        public virtual Portfolio Portfolio { get; set; }
        public virtual ApplicationUser Application { get; set; }
        public ICollection<ApplicationUser> applicationUsers { get; set; }



    }
}
