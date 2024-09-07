using CleanArchitechture.Domain;
using CleanArchitechture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitechture.Infrastructure
{
    public sealed class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> users { get; set; }

    }
}
