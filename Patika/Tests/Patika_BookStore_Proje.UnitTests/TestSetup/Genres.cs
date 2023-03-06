using System;
using Patika_BookStore_Proje.DBOperations;
using Patika_BookStore_Proje.Entities;

namespace TestSetup
{
    public static class Genres
    {
        public static void AddGenres(this BookStoreDbContext context)
        {
            context.Genres.AddRange(
                new Genre { Name = "Felsefe" },
                new Genre { Name = "Bilim" },
                new Genre { Name = "Roman" }
            );
        }
    }
}