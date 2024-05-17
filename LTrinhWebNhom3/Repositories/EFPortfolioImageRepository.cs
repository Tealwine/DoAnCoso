using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LTrinhWebNhom3.Data;
using LTrinhWebNhom3.Models;
using LTrinhWebNhom3.Repositories;


public class EFPortfolioImageRepository : IPortfolioImageRepository
{
    private readonly ApplicationDbContext _context;

    public EFPortfolioImageRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PortfolioImage>> GetAllAsync()
    {
        return await _context.PortfolioImages.ToListAsync();
    }

    public async Task<PortfolioImage> GetByIdAsync(int id)
    {
        return await _context.PortfolioImages.FindAsync(id);
    }

    public async Task AddAsync(PortfolioImage portfolioImage)
    {
        _context.PortfolioImages.Add(portfolioImage);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(PortfolioImage portfolioImage)
    {
        _context.PortfolioImages.Update(portfolioImage);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var portfolioImage = await _context.PortfolioImages.FindAsync(id);
        _context.PortfolioImages.Remove(portfolioImage);
        await _context.SaveChangesAsync();
    }
}