using Microsoft.EntityFrameworkCore;
using MVCStartApp.Models.Db;

namespace MVCStartApp.Models.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        // ссылка на контекст
        private readonly LoggingContext _context;

        // Метод-конструктор для инициализации
        public RequestRepository(LoggingContext context)
        {
            _context = context;
        }
        
        public async Task AddRequest(Request request)
        {
            request.Date = DateTime.Now;
            request.Id = Guid.NewGuid();

            // Добавление пользователя
            var entry = _context.Entry(request);
            if (entry.State == EntityState.Detached)
                await _context.Requests.AddAsync(request);

            // Сохранение изенений
            await _context.SaveChangesAsync();
        }

        public async Task<Request[]> GetRequests()
        {
            // Получим всех активных пользователей
            return await _context.Requests.ToArrayAsync();
        }
    }
}
