using LTrinhWebNhom3.Models;
using LTrinhWebNhom3.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LTrinhWebNhom3.Repositories
{
    public interface IPortfolioImageRepository
    {
        Task<IEnumerable<PortfolioImage>> GetAllAsync();
        Task<PortfolioImage> GetByIdAsync(int id);
        Task AddAsync(PortfolioImage portfolioImage);
        Task UpdateAsync(PortfolioImage portfolioImage);
        Task DeleteAsync(int id);
    }
}