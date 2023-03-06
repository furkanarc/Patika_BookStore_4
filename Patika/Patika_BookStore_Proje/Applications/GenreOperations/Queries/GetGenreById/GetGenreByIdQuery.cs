using System;
using System.Linq;
using AutoMapper;
using Patika_BookStore_Proje.DBOperations;

namespace Patika_BookStore_Proje.Applications.GenreOperations.Queries.GetGenreById
{
    public class GetGenreByIdQuery
    {
        public int GenreId { get; set; }
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetGenreByIdQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public GenreViewModel Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(x => x.IsActive && x.Id == GenreId);
            if (genre is null)  
                throw new InvalidOperationException("Bu Id'ye sahip bir tür bulunamadı.");
            return _mapper.Map<GenreViewModel>(genre);
        }
    }

    public class GenreViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}