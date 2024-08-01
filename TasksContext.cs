using Microsoft.EntityFrameworkCore;
using projectef.Models;

namespace projectef
{
    public class TasksContext: DbContext
    {
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }

        public TasksContext(DbContextOptions<TasksContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(category =>
            {
                category.ToTable("Category");
                category.HasKey(c => c.CategoryId);
                category.Property(c => c.Name).IsRequired().HasMaxLength(150);
                category.Property(c => c.Description);
                category.Property(c => c.Weight);
            });

            modelBuilder.Entity<Models.Task>(task =>
            {
                task.ToTable("Task");
                task.HasKey(t => t.TaskId);
                task.HasOne(c => c.Category).WithMany(t => t.Tasks).HasForeignKey(c =>  c.CategoryId);
                task.Property(t => t.Title).IsRequired().HasMaxLength(200);
                task.Property(t => t.Description);
                task.Property(t => t.PriorityTask);
                task.Property(t => t.DateCreated);
                task.Ignore(t => t.Resume);
            });
        }
    }
}
