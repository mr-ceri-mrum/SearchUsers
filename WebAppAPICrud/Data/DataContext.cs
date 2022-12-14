using Microsoft.EntityFrameworkCore;

namespace WebAppAPICrud.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public virtual DbSet<User> Users { get; set; } //Добавление сущности
    }
}
