using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookQuoteApiApp.Entities;
using Microsoft.CodeAnalysis.Scripting;
using Org.BouncyCastle.Crypto.Generators;

namespace BookQuoteApiApp.Data
{
    public class BookQuoteApiAppContext : DbContext
    {
        public BookQuoteApiAppContext (DbContextOptions<BookQuoteApiAppContext> options)
            : base(options)
        {
        }

        public DbSet<BookQuoteApiApp.Entities.Book> Book { get; set; } = default!;
        public DbSet<BookQuoteApiApp.Entities.Quote> Quote { get; set; } = default!;
        public DbSet<BookQuoteApiApp.Entities.User> User { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Books
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "To Kill a Mockingbird",
                    Author = "Harper Lee",
                    PublicationDate = new DateTime(1960, 7, 11)
                },
                new Book
                {
                    Id = 2,
                    Title = "1984",
                    Author = "George Orwell",
                    PublicationDate = new DateTime(1949, 6, 8)
                }
            );

            // Seed data for Quotes
            modelBuilder.Entity<Quote>().HasData(
                new Quote
                {
                    Id = 1,
                    QuoteText = "You never really understand a person until you consider things from his point of view.",
                    Author = "Harper Lee"
                },
                new Quote
                {
                    Id = 2,
                    QuoteText = "Big Brother is watching you.",
                    Author = "George Orwell"
                }
            );

            // Seed data for Users with hashed password
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "admin",
                    Password= "admin",
                },
                new User
                {
                    Id = 2,
                    Username = "user",
                    Password= "user",
                }
            );
        }

    }
}


