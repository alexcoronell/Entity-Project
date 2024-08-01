using Microsoft.EntityFrameworkCore;
using projectef.Models;
using System.Threading;

namespace projectef
{
    public class TasksContext: DbContext
    {
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }

        public TasksContext(DbContextOptions<TasksContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Category> categoriesInit = new List<Category>();
            categoriesInit.Add(new Category() {  
                CategoryId = Guid.Parse("8e6fd9a7-1fee-4b87-b724-b2c8b5aa75a0"),
                Name = "Pending Tasks",
                Weight = 20
            });
            categoriesInit.Add(new Category()
            {
                CategoryId = Guid.Parse("108e7a15-0cc3-456d-82c3-71e2c0d0b5c6"),
                Name = "Personal Tasks",
                Weight = 50
            });

            modelBuilder.Entity<Category>(category =>
            {
                category.ToTable("Category");
                category.HasKey(c => c.CategoryId);
                category.Property(c => c.Name).IsRequired().HasMaxLength(150);
                category.Property(c => c.Description).IsRequired(false);
                category.Property(c => c.Weight);
                category.HasData(categoriesInit);
            });

            List<Models.Task> tasksInit = new List<Models.Task>();
            tasksInit.Add(new Models.Task()
            {
                TaskId = Guid.Parse("26ddde96-39d7-4598-a401-80ed2ea504ce"),
                CategoryId = Guid.Parse("8e6fd9a7-1fee-4b87-b724-b2c8b5aa75a0"),
                Title = "Payment Public Services",
                PriorityTask = Priority.Mid,
                DateCreated = DateTime.Now,
            });

            tasksInit.Add(new Models.Task()
            {
                TaskId = Guid.Parse("6478568f-4f18-4001-8035-98c522b2f03a"),
                CategoryId = Guid.Parse("108e7a15-0cc3-456d-82c3-71e2c0d0b5c6"),
                Title = "Complete movie in Netflix",
                PriorityTask = Priority.Low,
                DateCreated = DateTime.Now,
            });

            modelBuilder.Entity<Models.Task>(task =>
            {
                task.ToTable("Task");
                task.HasKey(t => t.TaskId);
                task.HasOne(t => t.Category).WithMany(c => c.Tasks).HasForeignKey(t => t.CategoryId);
                task.Property(t => t.Title).IsRequired().HasMaxLength(200);
                task.Property(t => t.Description).IsRequired(false);
                task.Property(t => t.PriorityTask);
                task.Property(t => t.DateCreated);
                task.Ignore(t => t.Resume);
                task.HasData(tasksInit);
            });
        }
    }
}
