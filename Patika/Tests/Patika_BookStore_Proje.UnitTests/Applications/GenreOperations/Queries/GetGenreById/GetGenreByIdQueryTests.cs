using System;
using System.Linq;
using AutoMapper;
using TestSetup;
using Xunit;
using FluentAssertions;
using Patika_BookStore_Proje.DBOperations;
using Patika_BookStore_Proje.Applications.GenreOperations.Queries.GetGenreById;

namespace Applications.GenreOperations.Queries.GetGenreById
{
    public class GetGenreByIdQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetGenreByIdQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenGivenGenreIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
        {
            GetGenreByIdQuery query = new GetGenreByIdQuery(_context, null);
            query.GenreId = 0;

            FluentActions
                .Invoking(() => query.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Bu Id'ye sahip bir tür bulunamadı.");
        }

        [Fact]
        public void WhenGivenGenreIdIsInDB_InvalidOperationException_ShouldNotBeReturn()
        {
            GetGenreByIdQuery query = new GetGenreByIdQuery(_context, _mapper);
            query.GenreId = 1;

            FluentActions.Invoking(() => query.Handle()).Invoke();

            var genre = _context.Genres.SingleOrDefault(b => b.Id == query.GenreId);
            genre.Should().NotBeNull();
        }
    }
}