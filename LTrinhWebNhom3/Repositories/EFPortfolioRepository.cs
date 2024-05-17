using LTrinhWebNhom3.Data;
using LTrinhWebNhom3.Models;
using Microsoft.EntityFrameworkCore;

namespace LTrinhWebNhom3.Repositories
{
    public class EFPortfolioRepository : IPortfolioRepository
    {
        private readonly ApplicationDbContext _context;

        public EFPortfolioRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Portfolio>> GetAllAsync()
        {
            // return await _context.Products.ToListAsync();
            return await _context.Portfolios.Include(p => p.Tag) // Include thông tin về category
        .ToListAsync();
        }


        public async Task<Portfolio> GetByIdAsync(int id)
        {
            // return await _context.Products.FindAsync(id);
            // lấy thông tin kèm theo category
            return await _context.Portfolios.Include(p => p.Tag).FirstOrDefaultAsync(p => p.Id == id);
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
