using DogTypes.Models;
using Microsoft.EntityFrameworkCore;

public class DogDbContext : DbContext
{
    public DogDbContext(DbContextOptions<DogDbContext> options) : base(options)
    {
    }

    public DbSet<Breed> Breeds { get; set; }
    public DbSet<Dog> Dogs { get; set; }

}
