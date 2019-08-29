using Microsoft.EntityFrameworkCore;

namespace LibraryData
{
    public class TheDbContext:DbContext
    {
        public TheDbContext(DbContextOptions options) : base(options) { }
        public DbSet<TodoTask> TodoTasks { get; set; }
    }
}
