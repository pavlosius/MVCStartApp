using Microsoft.EntityFrameworkCore;

namespace MVCStartApp.Models.Db
{
    public sealed class LoggingContext : DbContext
    {
        /// Ссылка на таблицу Requests
        public DbSet<Request> Requests { get; set; }

        public LoggingContext(DbContextOptions<LoggingContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
