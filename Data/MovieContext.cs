using Microsoft.EntityFrameworkCore;
using MovieAPI.Models;

namespace MovieAPI.Data;

public class MovieContext : DbContext
{
    public object Movies { get; internal set; }

    public MovieContext(DbContextOptions<MovieContext> opts) : base(opts)
    {

    }

    public DbSet<Movie> Movie { get; set; }
    public DbSet<Cinema> Cinema { get; set; }
    public DbSet<Address> Address { get; set; }
}