using LTrinhWebNhom3.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LTrinhWebNhom3.Repositories
{
    public interface IProjectImageRespository
    {
        Task<IEnumerable<ProjectImage>> GetAllAsync();
        Task<ProjectImage> GetByIdAsync(int id);
        Task AddAsync(ProjectImage projectimage);
        Task UpdateAsync(ProjectImage projectimage);
        Task DeleteAsync(int id);
    }
}