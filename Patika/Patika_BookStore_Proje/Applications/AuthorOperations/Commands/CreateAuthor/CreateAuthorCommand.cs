using System;
using System.Linq;
using AutoMapper;
using Patika_BookStore_Proje.DBOperations;
using Patika_BookStore_Proje.Entities;

namespace Patika_BookStore_Proje.Applications.AuthorOperations.Commands.CreateAuthor{
    public class CreateAuthorCommand{
        public CreateAuthorModel Model {get;set;}
        private readonly IMapper _mapper;
        private readonly IBookStoreDbContext _dbContext;
        public CreateAuthorCommand(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle(){
            var author = _dbContext.Authors.SingleOrDefault(x => x.Ad == Model.Ad  && x.Soyad == Model.Soyad);
            if(author is not null)
                throw new InvalidOperationException("Bu isimde bir yazar zaten mevcut.");
            _dbContext.Authors.Add(_mapper.Map<Author>(Model));
            _dbContext.SaveChanges();
        }
    }

    public class CreateAuthorModel{
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string DogumTarihi { get; set; }
    }
}