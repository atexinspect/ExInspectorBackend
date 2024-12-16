using ExInspectorBackend.Models;
using ExInspectorBackend.Middleware;
using Microsoft.AspNetCore.Datasync;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDatasyncControllers();

var app = builder.Build();

// Initialize the database
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await context.InitializeDatabaseAsync().ConfigureAwait(false);
}

app.UseAuthorization();
app.UseMiddleware<Middleware>();
app.UseHttpsRedirection();

// Configure and run the web service.
app.MapControllers();
app.Run();