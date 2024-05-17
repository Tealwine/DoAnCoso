namespace LTrinhWebNhom3.Models
{
    public class Save
    {
        public List<SaveItem> Items { get; set; } = new List<SaveItem>();
        public void AddItem(SaveItem item)
        {
            var existingItem = Items.FirstOrDefault(i => i.PortfolioID ==
           item.PortfolioID);
            if (existingItem.Quantity != null)
            {
                existingItem.Quantity += item.Quantity;
            }
            else
            {
                Items.Add(item);
            }
        }
        public void RemoveItem(int portfolioID)
        {
            Items.RemoveAll(i => i.PortfolioID == portfolioID);
        }
        // Các phương thức khác...

    }
}



