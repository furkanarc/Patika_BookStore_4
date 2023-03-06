using System;
using System.Linq;
using Patika_BookStore_Proje.Common;
using Patika_BookStore_Proje.DBOperations;

namespace Patika_BookStore_Proje.Applications.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommand
    {
        public int BookId { get; set; }
        private readonly IBookStoreDbContext _dbContext;
        public DeleteBookCommand(IBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle(){
            var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);
            if(book is null) 
                throw new InvalidOperationException("Silinecek kitap bulunamadı.");
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }
    }
}