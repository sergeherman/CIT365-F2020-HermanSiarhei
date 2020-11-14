using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "The RM",
                        Rating = "G",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Drama",
                        Price = 7.99M
                    },

                    new Movie
                    {
                        Title = "Other Side of Heaven",
                        Rating = "G",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Drama",
                        Price = 8.99M
                    },

                    new Movie
                    {
                        Title = "Meet the Mormons2",
                        Rating = "G",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "NonFiction",
                        Price = 9.99M
                    },

                    new Movie
                    {
                        Title = "Meet the Mormons",
                        Rating = "G",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "NonFiction",
                        Price = 3.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}