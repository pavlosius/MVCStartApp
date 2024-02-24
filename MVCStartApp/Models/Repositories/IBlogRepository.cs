using MVCStartApp.Models.Db;

namespace MVCStartApp.Models.Repositories
{
    public interface IBlogRepository
    {
        Task AddUser(User user);
        Task<User[]> GetUsers();
    }
}
