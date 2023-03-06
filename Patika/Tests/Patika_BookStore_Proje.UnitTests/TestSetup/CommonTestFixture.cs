using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Patika_BookStore_Proje.Common;
using Patika_BookStore_Proje.DBOperations;

namespace TestSetup{
    public class CommonTestFixture
    {
        public BookStoreDbContext Context { get; set;}
        public IMapper Mapper { get; set;}
        public CommonTestFixture()
        {
            var options = new DbContextOptionsBuilder<BookStoreDbContext>().UseInMemoryDatabase(databaseName:"BookStoreTestDB").Options;
            Context = new BookStoreDbContext(options);
            Context.Database.EnsureCreated();
            Context.AddBooks();
            Context.AddGenres();
            Context.AddAuthors();
            Context.SaveChanges();

            Mapper = new MapperConfiguration(cfg => {cfg.AddProfile<MappingProfile>(); }).CreateMapper();
        }
    }
}