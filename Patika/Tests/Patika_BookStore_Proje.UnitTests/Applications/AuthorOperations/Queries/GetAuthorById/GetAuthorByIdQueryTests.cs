using System;
using System.Linq;
using AutoMapper;
using TestSetup;
using Xunit;
using FluentAssertions;
using Patika_BookStore_Proje.DBOperations;
using Patika_BookStore_Proje.Applications.AuthorOperations.Queries.GetAuthorById;

namespace Applications.AuthorOperations.Queries.GetAuthorById
{
    public class GetAuthorByIdQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetAuthorByIdQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenGivenAuthorIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
        {
            GetAuthorByIdQuery query = new GetAuthorByIdQuery(_context, null);
            query.AuthorId = 0;

            FluentActions
                .Invoking(() => query.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Bu Id'ye sahip bir yazar bulunamadı.");
        }

        [Fact]
        public void WhenGivenAuthorIdIsInDB_InvalidOperationException_ShouldNotBeReturn()
        {
            GetAuthorByIdQuery query = new GetAuthorByIdQuery(_context, _mapper);
            query.AuthorId = 1;

            FluentActions.Invoking(() => query.Handle()).Invoke();

            var Author = _context.Authors.SingleOrDefault(b => b.Id == query.AuthorId);
            Author.Should().NotBeNull();
        }
    }
}