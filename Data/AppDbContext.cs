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
    }
}
