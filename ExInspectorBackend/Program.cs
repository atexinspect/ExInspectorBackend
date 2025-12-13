using CommunityToolkit.Datasync.Server;
using ExInspectorBackend.Controllers;
using ExInspectorBackend.Middleware;
using ExInspectorBackend.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDatasyncServices();
builder.Services.AddControllers();

var app = builder.Build();

// Initialize the database with migrations
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    
    // Apply any pending migrations
    await context.Database.MigrateAsync().ConfigureAwait(false);
    
    // Install/update datasync triggers
    const string datasyncTrigger = @"
        CREATE OR ALTER TRIGGER [dbo].[{0}_datasync] ON [dbo].[{0}] AFTER INSERT, UPDATE AS
        BEGIN
            SET NOCOUNT ON;
            UPDATE
                [dbo].[{0}]
            SET
                [UpdatedAt] = SYSUTCDATETIME()
            WHERE
                [Id] IN (SELECT [Id] FROM INSERTED);
        END
    ";

    foreach (var table in context.Model.GetEntityTypes())
    {
        string sql = string.Format(datasyncTrigger, table.GetTableName());
        await context.Database.ExecuteSqlRawAsync(sql).ConfigureAwait(false);
    }
}

app.UseAuthorization();
app.UseMiddleware<Middleware>();

app.UseHttpsRedirection();

// Configure and run the web service.
app.MapControllers();
app.MapBackendEndpoints();
app.Run();