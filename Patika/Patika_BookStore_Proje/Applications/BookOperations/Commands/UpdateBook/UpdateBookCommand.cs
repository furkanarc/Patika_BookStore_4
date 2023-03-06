using System;
using System.Linq;
using Patika_BookStore_Proje.DBOperations;

namespace Patika_BookStore_Proje.Applications.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommand
    {
        public int BookId { get; set; }
        public UpdateBookModel Model { get; set; }
        private readonly IBookStoreDbContext _dbContext;
        public UpdateBookCommand(IBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);
            if (book is null)
                throw new InvalidOperationException("Geçersiz BookId");
            if (_dbContext.Books.Any(x => x.Title.ToLower() == Model.Title.ToLower() && x.Id != BookId))
                throw new InvalidOperationException("Bu isimde kitap zaten mevcut.");
            book.GenreId = Model.GenreId;
            book.Title = string.IsNullOrEmpty(Model.Title.Trim()) ? book.Title : Model.Title;
            _dbContext.SaveChanges();
        }

    }
    public class UpdateBookModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
    }
}