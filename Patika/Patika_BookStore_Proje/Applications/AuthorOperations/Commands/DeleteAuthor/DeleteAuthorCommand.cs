using System;
using System.Linq;
using Patika_BookStore_Proje.DBOperations;

namespace Patika_AuthorStore_Proje.Applications.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        public int AuthorId { get; set; }
        private readonly IBookStoreDbContext _dbContext;
        public DeleteAuthorCommand(IBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle(){
            var author = _dbContext.Authors.SingleOrDefault(x => x.Id == AuthorId);
            var authorBooks = _dbContext.Books.FirstOrDefault(x => x.AuthorId == AuthorId);
            if(author is null) 
                throw new InvalidOperationException("Silinecek yazar bulunamadı.");
            if(authorBooks is not null)
                throw new InvalidOperationException("Önce yazarın kitapları silinmeli");
            _dbContext.Authors.Remove(author);
            _dbContext.SaveChanges();
        }
    }
}