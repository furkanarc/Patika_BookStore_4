using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Patika_BookStore_Proje.DBOperations;

namespace Patika_BookStore_Proje.Applications.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorsQuery
    {
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetAuthorsQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<AuthorViewModel> Handle()
        {
            var authors = _dbContext.Authors.OrderBy(x => x.Id);
            
            return _mapper.Map<List<AuthorViewModel>>(authors);
        }

     
    }
    public class AuthorViewModel
    {
        public int Id { get; set; }
        public string Name {get; set;}
        public string DogumTarihi {get; set;}
    }
}