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

//app.MapGet("/api/tasks", async ([FromServices] TasksContext dbContext) =>
//{
//    return Results.Ok(dbContext.Tasks.Include(c => c.Category).Where(t => t.PriorityTask == Priority.Low));
//});

app.MapGet("/api/tasks", async ([FromServices] TasksContext dbContext) =>
{
    return Results.Ok(dbContext.Tasks.Include(c => c.Category));
});

app.MapPost("/api/tasks", async ([FromServices] TasksContext dbContext, [FromBody] projectef.Models.Task task) =>
{
    task.TaskId = Guid.NewGuid();
    task.DateCreated = DateTime.Now;
    Console.WriteLine(task);
    await dbContext.Tasks.AddAsync(task);
    //await dbContext.AddAsync(task);

    await dbContext.SaveChangesAsync();
    return Results.Ok();
});

app.Run();
