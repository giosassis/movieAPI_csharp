using Microsoft.EntityFrameworkCore;
using MovieAPI.Models;

namespace MovieAPI.Data;

public class MovieContext : DbContext
{
    public object Movies { get; set; }

    public MovieContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Movie> Movie { get; set; }
    public DbSet<Cinema> Cinema { get; set; }
    public DbSet<Address> Address { get; set; }
    public DbSet<Session> Sessions { get; set; }
}