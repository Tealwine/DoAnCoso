namespace LTrinhWebNhom3.Models
{
     public class PortfolioImage
    {
        public int Id { get; set; }
        public int PortfolioID { get; set; }
        
        public string ImageURL { get; set; }
      
        public Portfolio Portfolio { get; set; }

    }
}
