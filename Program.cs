using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectef;

var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddDbContext<TasksContext>(db => db.UseInMemoryDatabase("TasksDB"));
// builder.Services.AddSqlServer<TasksContext>("Initial Catalog= TareasDb;Trusted_Connection=True; Integrated Security=True");
builder.Services.AddSqlServer<TasksContext>(builder.Configuration.GetConnectionString("cnTasks"));
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/dbconnection", async ([FromServices] TasksContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
});

app.MapGet("/api/tasks", async ([FromServices] TasksContext dbContext) =>
{
    return Results.Ok(dbContext.Tasks.Include(c => c.Category).Where(t => t.PriorityTask == Priority.Low));
});

app.Run();
