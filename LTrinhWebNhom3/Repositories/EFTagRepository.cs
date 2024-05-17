using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LTrinhWebNhom3.Data;
using LTrinhWebNhom3.Models;
using LTrinhWebNhom3.Repositories;
using Model.Repositories;

public class EFTagRepository : ITagRepository
{
    private readonly ApplicationDbContext _context;

    public EFTagRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Tag>> GetAllAsync()
    {
        return await _context.Tags.ToListAsync();
    }

    public async Task<Tag> GetByIdAsync(int id)
    {
        return await _context.Tags.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task AddAsync(Tag tag)
    {
        _context.Tags.Add(tag);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Tag tag)
    {
        _context.Tags.Update(tag);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var tag = await _context.Tags.FindAsync(id);
        _context.Tags.Remove(tag);
        await _context.SaveChangesAsync();
    }
}
