using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Patika_BookStore_Proje.DBOperations;

namespace Patika_BookStore_Proje.Applications.GenreOperations.Queries.GetGenres
{
    public class GetGenresQuery
    {
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetGenresQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<GenresViewModel> Handle()
        {
            var genres = _dbContext.Genres.Where(x => x.IsActive).OrderBy(x => x.Id);
            
            return _mapper.Map<List<GenresViewModel>>(genres);
        }
    }

    public class GenresViewModel
    {
        public int Id { get; set; }
        public string Name {get; set;}
    }
}