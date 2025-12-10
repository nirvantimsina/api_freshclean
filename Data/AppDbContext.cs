using Microsoft.EntityFrameworkCore;
using api_freshclean.Models;

namespace api_freshclean.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Quote> Quotes { get; set; }
    public DbSet<Newsletter> Newsletters { get; set; }
    public DbSet<Contact> Contacts { get; set; }
}