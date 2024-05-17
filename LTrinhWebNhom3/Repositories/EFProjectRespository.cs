
using Microsoft.EntityFrameworkCore;
using LTrinhWebNhom3.Models;
using LTrinhWebNhom3.Data;
namespace LTrinhWebNhom3.Repositories
{
    public class EFProjectRespository : IProjectRepository
    {

        private readonly ApplicationDbContext _context;

        public EFProjectRespository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            return await _context.Projects.ToListAsync();
          
        }


        public async Task<Project> GetByIdAsync(int id)
        {
            // return await _context.Products.FindAsync(id);
            // lấy thông tin kèm theo category
            return await _context.Projects.Include(p => p.Tag).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Portfolio portfolio)
        {
            _context.Portfolios.Add(portfolio);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Portfolio portfolio)
        {
            _context.Portfolios.Update(portfolio);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var portfolio = await _context.Portfolios.FindAsync(id);
            _context.Portfolios.Remove(portfolio);
            await _context.SaveChangesAsync();
        }
        public async Task AddPortfolioAsync(Portfolio portfolio)
        {
            _context.Portfolios.Add(portfolio);
            await _context.SaveChangesAsync();
        }
        public async Task UpdatePortfolioAsync(Portfolio portfolio)
        {
            _context.Entry(portfolio).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeletePortfolioAsync(int id)
        {
            var portfolio = await _context.Portfolios.FindAsync(id);
            if (portfolio != null)
            {
                _context.Portfolios.Remove(portfolio);
                await _context.SaveChangesAsync();
            }
        }
    }

}
