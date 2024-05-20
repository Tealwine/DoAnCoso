
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
            return await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Project project)
        {
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
        }

    }

}
