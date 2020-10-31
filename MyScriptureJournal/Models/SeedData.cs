using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyScriptureJournal.Data;
using System;
using System.Linq;

namespace MyScriptureJournal.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyScriptureJournalContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MyScriptureJournalContext>>()))
            {
                // Look for any Scriptures.
                if (context.Scripture.Any())
                {
                    return;   // DB has been seeded
                }

                context.Scripture.AddRange(
                    new Scripture
                    {
                        Book = "Test1",
                        AddedDate = DateTime.Parse("1989-2-12"),
                        Note = "Note Test 1",
                        Chapter = 1,
                        Verse = 2
                    },

                    new Scripture
                    {
                        Book = "Test2 ",
                        AddedDate = DateTime.Parse("1984-3-13"),
                        Note = "Note Test 2",
                        Chapter = 1,
                        Verse = 2
                    },

                    new Scripture
                    {
                        Book = "Test3",
                        AddedDate = DateTime.Parse("1986-2-23"),
                        Note = "Note Test 3",
                        Chapter = 1,
                        Verse = 2
                    },

                    new Scripture
                    {
                        Book = "Test4",
                        AddedDate = DateTime.Parse("1959-4-15"),
                        Note = "Note Test 4",
                        Chapter = 1,
                        Verse = 2
                    }
                );
                context.SaveChanges();
            }
        }
    }
}