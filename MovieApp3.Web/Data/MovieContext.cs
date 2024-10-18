using Microsoft.EntityFrameworkCore;
using MovieApp3.Web.Entity;
using System;

namespace MovieApp3.Web.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
            //startuptaki optionları base gönderdik.
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Director> Directors { get; set; }

        //public DbSet<User> Users { get; set; }
        //public DbSet<Person> People { get; set; }
        //public DbSet<Crew> Crews { get; set; }
        //public DbSet<Cast> Casts { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=movie.db");
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Movie>().Property(b => b.Title).IsRequired();
        //    modelBuilder.Entity<Movie>().Property(b => b.Title).HasMaxLength(500);
        //    modelBuilder.Entity<Genre>().Property(b => b.Name).IsRequired();
        //    modelBuilder.Entity<Genre>().Property(b => b.Name).HasMaxLength(50);
        //}
    }
}
