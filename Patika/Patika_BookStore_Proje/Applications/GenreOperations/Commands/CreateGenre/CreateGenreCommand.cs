using System;
using System.Linq;
using Patika_BookStore_Proje.DBOperations;
using Patika_BookStore_Proje.Entities;

namespace Patika_BookStore_Proje.Applications.GenreOperations.Commands.CreateGenre{
    public class CreateGenreCommand{
        public CreateGenreModel Model {get;set;}
        private readonly IBookStoreDbContext _dbContext;
        public CreateGenreCommand(IBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle(){
            var genre = _dbContext.Genres.SingleOrDefault(x => x.Name == Model.Name);
            if(genre is not null)
                throw new InvalidOperationException("Kitap türü zaten mevcut");

            genre = new Genre();
            genre.Name = Model.Name;
            _dbContext.Genres.Add(genre);
            _dbContext.SaveChanges();
        }
    }
    
    public class CreateGenreModel{
        public string Name {get;set;}
    }
}