using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace LTrinhWebNhom3.Models
{
   
    public class Portfolio
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public List<PortfolioImage>? Images { get; set; }
        public int TagID { get; set; }  
        public Tag? Tag { get; set; }
        public int ProjectID { get; set; }
        public Project projects { get; set; }
    }

   

    
}
