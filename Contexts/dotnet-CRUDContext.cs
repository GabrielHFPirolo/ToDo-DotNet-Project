using dotnet_CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_CRUD.Contexts;

public class TodosContext : DbContext
{
    public DbSet<Todo> Todos => Set<Todo>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=todos.sqlite3");
    }
}
