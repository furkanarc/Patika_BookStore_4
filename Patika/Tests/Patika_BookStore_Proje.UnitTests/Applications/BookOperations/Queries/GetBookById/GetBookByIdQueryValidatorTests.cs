using FluentAssertions;
using TestSetup;
using Patika_BookStore_Proje.Applications.BookOperations.Queries.GetBookById;
using Xunit;

namespace Applications.BookOperations.Queries.GetBookById
{
    public class GetBookByIdQueryValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void WhenInvalidBookidIsGiven_Validator_ShouldBeReturnError(int bookid)
        {
            GetBookByIdQuery query = new GetBookByIdQuery(null,null);
            query.BookId = bookid;

            GetBookByIdQueryValidator validator = new GetBookByIdQueryValidator();
            var result = validator.Validate(query);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidBookIdIsGiven_Validator_ShouldNotBeReturnError()
        {
            GetBookByIdQuery query = new GetBookByIdQuery(null,null);
            query.BookId = 1;

            GetBookByIdQueryValidator validator = new GetBookByIdQueryValidator();
            var result = validator.Validate(query);

            result.Errors.Count.Should().Equals(0);
        }


    }
}