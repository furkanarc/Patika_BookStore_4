using System;
using System.Linq;
using AutoMapper;
using TestSetup;
using Xunit;
using FluentAssertions;
using Patika_BookStore_Proje.DBOperations;
using Patika_BookStore_Proje.Applications.BookOperations.Queries.GetBookById;

namespace Applications.BookOperations.Queries.GetBookById
{
    public class GetBookByIdQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetBookByIdQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenGivenBookIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
        {
            GetBookByIdQuery query = new GetBookByIdQuery(_context, null);
            query.BookId = 0;

            FluentActions
                .Invoking(() => query.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Bu Id'ye sahip bir kitap bulunamadı.");
        }

        [Fact]
        public void WhenGivenBookIdIsInDB_InvalidOperationException_ShouldNotBeReturn()
        {
            GetBookByIdQuery query = new GetBookByIdQuery(_context, _mapper);
            query.BookId = 1;

            FluentActions.Invoking(() => query.Handle()).Invoke();

            var book = _context.Books.SingleOrDefault(b => b.Id == query.BookId);
            book.Should().NotBeNull();
        }
    }
}