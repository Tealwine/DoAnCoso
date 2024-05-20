using LTrinhWebNhom3.Data;
using LTrinhWebNhom3.Models;
using Microsoft.EntityFrameworkCore;

namespace LTrinhWebNhom3.Repositories
{
    public class EFProjectImageRespository : IProjectImageRespository
    {

        private readonly ApplicationDbContext _context;

        public EFProjectImageRespository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProjectImage>> GetAllAsync()
        {
            return await _context.ProjectImages.ToListAsync();
        }

        public async Task<ProjectImage> GetByIdAsync(int id)
        {
            return await _context.ProjectImages.FindAsync(id);
        }

        public async Task AddAsync(ProjectImage projectImage)
        {
            _context.ProjectImages.Add(projectImage);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProjectImage projectImage)
        {
            _context.ProjectImages.Update(projectImage);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var projectImage = await _context.ProjectImages.FindAsync(id);
            _context.ProjectImages.Remove(projectImage);
            await _context.SaveChangesAsync();
        }

    }
}
