using Microsoft.EntityFrameworkCore;


using ASPTask.Models;
using ASPTask.Models.ViewModels;

namespace ASPTask.Data
{
    public class TaskDBContext : DbContext
    {

        public TaskDBContext(DbContextOptions<TaskDBContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}