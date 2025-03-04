using Microsoft.EntityFrameworkCore;
using SteelCMS.Shared;

public class SteelDbContext : DbContext
{
    public SteelDbContext(DbContextOptions<SteelDbContext> options) : base(options) { }

    public DbSet<Steel> Steels { get; set; }
    public DbSet<User> Users { get; set; }
}

public class Steel
{
    public int Id { get; set; }
    public string Name { get; set; }
}
