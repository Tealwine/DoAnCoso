using LTrinhWebNhom3.Models;

namespace LTrinhWebNhom3.Repositories
{
    public interface IApplicationUserRepository
    {
        Task<List<ApplicationUser>> GetUsersAsync();
        Task<ApplicationUser> GetUserByIdAsync(string id);
        Task<ApplicationUser> CreateUserAsync(ApplicationUser user, string password);
        Task<ApplicationUser> UpdateUserAsync(ApplicationUser user);
        Task DeleteUserAsync(string id);
    }
}
