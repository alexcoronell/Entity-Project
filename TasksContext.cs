using Microsoft.EntityFrameworkCore;
using projectef.Models;

namespace projectef
{
    public class TasksContext: DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }

        public TasksContext(DbContextOptions<TasksContext> options) : base(options);
    }
}
