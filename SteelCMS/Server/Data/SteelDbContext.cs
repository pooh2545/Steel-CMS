using Microsoft.EntityFrameworkCore;
using SteelCMS.Shared;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class SteelDbContext : DbContext
{
    public SteelDbContext(DbContextOptions<SteelDbContext> options) : base(options) { }

    public DbSet<customers> customers { get; set; }
    public DbSet<employee> employee { get; set; }
    public DbSet<steeltype> steeltype { get; set; }
}

