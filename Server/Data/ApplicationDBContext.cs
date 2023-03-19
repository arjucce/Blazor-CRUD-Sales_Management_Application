using Microsoft.EntityFrameworkCore;
using SalesManagementApp.Shared.Models;

namespace SalesManagementApp.Server.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Windows> Windows { get; set; }
        public DbSet<Subelements> Elements { get; set; }
        public DbSet<Orders> Orders { get; set; }
    }
}
