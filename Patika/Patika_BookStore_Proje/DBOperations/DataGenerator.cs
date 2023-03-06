

using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Patika_BookStore_Proje.Entities;

namespace Patika_BookStore_Proje.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                // Look for any book.
                if (context.Books.Any())
                {
                    return;   // Data was already seeded
                }

                context.Genres.AddRange(
                    new Genre { Name = "Felsefe" },
                    new Genre { Name = "Bilim" },
                    new Genre { Name = "Roman" }
                );

                context.Authors.AddRange(
                    new Author { Ad = "Desiderius", Soyad = "Erasmus", DogumTarihi = "28.10.1466" },
                    new Author { Ad = "Emil Michel", Soyad = "Cioran", DogumTarihi = "08.04.1911" },
                    new Author { Ad = "Albert", Soyad = "Einstein", DogumTarihi = "14.04.1879" },
                    new Author { Ad = "Sabahattin", Soyad = "Ali", DogumTarihi = "25.02.1907" },
                    new Author { Ad = "Paulo", Soyad = "Coelho", DogumTarihi = "24.08.1947" },
                    new Author { Ad = "Fyodor Mihayloviç", Soyad = "Dostoyevski", DogumTarihi = "11.11.1821" },
                    new Author { Ad = "Herman", Soyad = "Herman", DogumTarihi = "01.08.1947" }
                );

                context.Books.AddRange(
                    new Book { Title = "Deliliğe Övgü", AuthorId = 1, GenreId = 1, PageCount = 152, PublishDate = new DateTime(2016, 01, 01) },
                    new Book { Title = "Çürümenin Kitabı", AuthorId = 2, GenreId = 1, PageCount = 168, PublishDate = new DateTime(2000, 02, 02) },
                    new Book { Title = "İzafiyet Teorisi", AuthorId = 3, GenreId = 2, PageCount = 149, PublishDate = new DateTime(2004, 03, 03) },
                    new Book { Title = "Kürk Mantolu Madonna", AuthorId = 4, GenreId = 3, PageCount = 160, PublishDate = new DateTime(1998, 04, 04) },
                    new Book { Title = "Simyacı", AuthorId = 5, GenreId = 3, PageCount = 188, PublishDate = new DateTime(2010, 04, 04) },
                    new Book { Title = "Suç ve Ceza", AuthorId = 6, GenreId = 3, PageCount = 687, PublishDate = new DateTime(2006, 04, 04) }
                );
                context.SaveChanges();
            }
        }
    }
}