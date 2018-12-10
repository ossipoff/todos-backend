using System;
using Microsoft.EntityFrameworkCore;

namespace TodosBackend.EntityFramework
{
    public class TodosContext : DbContext
    {
        public TodosContext(DbContextOptions<TodosContext> options)
            : base(options)
        { }

        public DbSet<Models.Todo> Todos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=todos.db");
        }
    }
}