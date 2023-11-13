using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TodoList
{
    public class TodoContext : DbContext
    {
        public TodoContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskList> TaskLists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=TodoDatabase.db");
        }
    }
}