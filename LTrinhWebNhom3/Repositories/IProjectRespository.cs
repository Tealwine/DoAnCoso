using LTrinhWebNhom3.Models;
namespace LTrinhWebNhom3.Repositories
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAllAsync();
        Task<Project> GetByIdAsync(int id);
        Task AddAsync(Project project);
        Task UpdateAsync(Project project);
        Task DeleteAsync(int id);
    }
}
