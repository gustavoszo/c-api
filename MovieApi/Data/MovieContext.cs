using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MovieApi.Models;

namespace MovieApi.Data
{
    public class MovieContext: DbContext
    {

        public MovieContext(DbContextOptions<MovieContext> opts) : base(opts)
        { }

        public DbSet<Movie> movies { get; set; }

    }
}
