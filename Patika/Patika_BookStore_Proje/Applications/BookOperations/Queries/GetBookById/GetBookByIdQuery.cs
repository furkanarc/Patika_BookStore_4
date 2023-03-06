using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Patika_BookStore_Proje.Common;
using Patika_BookStore_Proje.DBOperations;

namespace Patika_BookStore_Proje.Applications.BookOperations.Queries.GetBookById{
    public class GetBookByIdQuery
    {
        public int BookId {get; set;}
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetBookByIdQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public BookViewModel Handle(){
            var book =  _dbContext.Books.Include(x => x.Genre).Where(x => x.Id == BookId).SingleOrDefault();
            if (book is null)
                throw new InvalidOperationException("Bu Id'ye sahip bir kitap bulunamadı.");
            
            return _mapper.Map<BookViewModel>(book);
        }
    }

    public class BookViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
}