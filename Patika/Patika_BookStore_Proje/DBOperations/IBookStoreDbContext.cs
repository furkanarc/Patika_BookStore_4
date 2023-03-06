using Microsoft.EntityFrameworkCore;
using Patika_BookStore_Proje.Entities;

namespace Patika_BookStore_Proje.DBOperations
{
    public interface IBookStoreDbContext
    {
        DbSet<Book> Books { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<Author> Authors { get; set; }
        int SaveChanges();
    }
}