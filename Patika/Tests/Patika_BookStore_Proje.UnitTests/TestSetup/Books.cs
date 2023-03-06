using System;
using Patika_BookStore_Proje.DBOperations;
using Patika_BookStore_Proje.Entities;

namespace TestSetup
{
    public static class Books
    {
        public static void AddBooks(this BookStoreDbContext context)
        {
            context.Books.AddRange(
                new Book { Title = "Deliliğe Övgü", AuthorId = 1, GenreId = 1, PageCount = 152, PublishDate = new DateTime(2016, 01, 01) },
                new Book { Title = "Çürümenin Kitabı", AuthorId = 2, GenreId = 1, PageCount = 168, PublishDate = new DateTime(2000, 02, 02) },
                new Book { Title = "İzafiyet Teorisi", AuthorId = 3, GenreId = 2, PageCount = 149, PublishDate = new DateTime(2004, 03, 03) },
                new Book { Title = "Kürk Mantolu Madonna", AuthorId = 4, GenreId = 3, PageCount = 160, PublishDate = new DateTime(1998, 04, 04) },
                new Book { Title = "Simyacı", AuthorId = 5, GenreId = 3, PageCount = 188, PublishDate = new DateTime(2010, 04, 04) },
                new Book { Title = "Suç ve Ceza", AuthorId = 6, GenreId = 3, PageCount = 687, PublishDate = new DateTime(2006, 04, 04) }
            );
        }
    }
}