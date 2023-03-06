using System;
using Patika_BookStore_Proje.DBOperations;
using Patika_BookStore_Proje.Entities;

namespace TestSetup
{
    public static class Authors
    {
        public static void AddAuthors(this BookStoreDbContext context)
        {
            context.Authors.AddRange(
                new Author { Ad = "Desiderius", Soyad = "Erasmus", DogumTarihi = "28.10.1466" },
                new Author { Ad = "Emil Michel", Soyad = "Cioran", DogumTarihi = "08.04.1911" },
                new Author { Ad = "Albert", Soyad = "Einstein", DogumTarihi = "14.04.1879" },
                new Author { Ad = "Sabahattin", Soyad = "Ali", DogumTarihi = "25.02.1907" },
                new Author { Ad = "Paulo", Soyad = "Coelho", DogumTarihi = "24.08.1947" },
                new Author { Ad = "Fyodor Mihayloviç", Soyad = "Dostoyevski", DogumTarihi = "11.11.1821" },
                new Author { Ad = "Herman", Soyad = "Herman", DogumTarihi = "01.08.1947" }
            );
        }
    }
}