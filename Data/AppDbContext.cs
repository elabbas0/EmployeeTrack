using Microsoft.EntityFrameworkCore;
using EmployeeTrack.Models.Entities;
namespace EmployeeTrack.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Visit> Visits { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Position> Positions { get; set; }


    }
}
