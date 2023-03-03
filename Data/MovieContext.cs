using Microsoft.EntityFrameworkCore;
using MovieAPI.Models;

namespace MovieAPI.Data;

public class MovieContext : DbContext
{
    public object Movies { get; set; }

    public MovieContext(DbContextOptions<MovieContext> opts, object movies, DbSet<Movie> movie, DbSet<Cinema?> cinema, DbSet<Address?> address) : base(opts)
    {
        Movies = movies;
        Movie = movie;
        Cinema = cinema;
        Address = address;
    }

    public DbSet<Movie> Movie { get; set; }
    public DbSet<Cinema?> Cinema { get; set; }
    public DbSet<Address?> Address { get; set; }
}