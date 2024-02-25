using MVCStartApp.Models.Db;

namespace MVCStartApp.Models.Repositories
{
    public interface IRequestRepository
    {
        Task AddRequest(Request request);
        Task<Request[]> GetRequests();
    }
}
