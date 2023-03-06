using System;
using System.Linq;
using AutoMapper;
using Patika_BookStore_Proje.DBOperations;
using Patika_BookStore_Proje.Entities;

namespace Patika_BookStore_Proje.Applications.BookOperations.Commands.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model { get; set; }
        private readonly IMapper _mapper;
        private readonly IBookStoreDbContext _dbContext;
        public CreateBookCommand(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Title == Model.Title);
            if (book is not null)
                throw new InvalidOperationException("Bu isimde bir kitap zaten mevcut.");
            _dbContext.Books.Add(_mapper.Map<Book>(Model));
            _dbContext.SaveChanges();
        }
    }

    public class CreateBookModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int AuthorId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}