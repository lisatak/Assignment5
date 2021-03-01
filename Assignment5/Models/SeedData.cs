using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5.Models
{
    public class SeedData
    {
        
        public static void EnsurePopulated (IApplicationBuilder application)
        {
            BooksDbContext context = application.ApplicationServices.
                CreateScope().ServiceProvider.GetRequiredService<BooksDbContext>();
            //Migrates data if there are pending migrations

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            //Seeds data if there are no saved data
            if (!context.Books.Any())
            {
                context.Books.AddRange(
                    new Books
                    {
                        Title = "Les Miserables",
                        AuthorFirstName = "Victor",
                        AuthorLastName = "Hugo",
                        Publisher = "Signet",
                        ISBN = "978-0451419439",
                        Classification = "Fiction",
                        Category = "Classic",
                        Price = 9.95,
                        Pages = 1488
                    },
                    new Books
                    {
                        Title = "Team of Rivals",
                        AuthorFirstName = "Doris Kearns",
                        AuthorLastName = "Goodwin",
                        Publisher = "Simon & Schuster",
                        ISBN = "978-0743270755",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 14.58,
                        Pages = 944
                    },
                    new Books
                    {
                        Title = "The Snowball",
                        AuthorFirstName = "Alice",
                        AuthorLastName = "Schroeder",
                        Publisher = "Bantam",
                        ISBN = "978-0553384611",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 21.54,
                        Pages = 832
                    },
                    new Books
                    {
                        Title = "American Ulysses",
                        AuthorFirstName = "Ronald C.",
                        AuthorLastName = "White",
                        Publisher = "Random House",
                        ISBN = "978-0812981254",
                        Classification = "Non-Fiction",
                        Category = "Historical",
                        Price = 11.61,
                        Pages = 864
                    },
                    new Books
                    {
                        Title = "The Great Train Robbery",
                        AuthorFirstName = "Michael",
                        AuthorLastName = "Crichton",
                        Publisher = "Vintage",
                        ISBN = "978-0804171281",
                        Classification = "Fiction",
                        Category = "Historical Fiction",
                        Price = 13.33,
                        Pages = 528
                    },
                    new Books
                    {
                        Title = "Deep Work",
                        AuthorFirstName = "Cal",
                        AuthorLastName = "Newport",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455586691",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = 13.33,
                        Pages = 288
                    },
                    new Books
                    {
                        Title = "Harry Potter",
                        AuthorFirstName = "J. K.",
                        AuthorLastName = "Rowling",
                        Publisher = "A Publisher",
                        ISBN = "978-1234567890",
                        Classification = "Fiction",
                        Category = "Fantasy",
                        Price = 10.97,
                        Pages = 318
                    },
                    new Books
                    {
                        Title = "Fight Club",
                        AuthorFirstName = "Chuck",
                        AuthorLastName = "Palahniuk",
                        Publisher = "Soap Publishing",
                        ISBN = "0987654321",
                        Classification = "Fiction",
                        Category = "Fighting",
                        Price = 8.54,
                        Pages = 358
                    },
                    new Books
                    {
                        Title = "Milkweed",
                        AuthorFirstName = "Jerry",
                        AuthorLastName = "Spinelli",
                        Publisher = "Milk Publishing",
                        ISBN = "978-1212121211",
                        Classification = "Fiction",
                        Category = "Historical Fiction",
                        Price = 7.33,
                        Pages = 239
                    },
                    new Books
                    {
                        Title = "The Book of Mormon",
                        AuthorFirstName = "Mormon",
                        AuthorLastName = "Moroni",
                        Publisher = "Church of Jesus Christ of Latter-day Saints",
                        ISBN = "978-9999999999",
                        Classification = "Non-Fiction",
                        Category = "Religious",
                        Price = 0.99,
                        Pages = 681
                    }


                );

                context.SaveChanges();
            }
        }
    }
}
