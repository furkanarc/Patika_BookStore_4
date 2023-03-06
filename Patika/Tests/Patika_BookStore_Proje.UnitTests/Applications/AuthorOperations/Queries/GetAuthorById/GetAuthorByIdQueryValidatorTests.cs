using FluentAssertions;
using Patika_BookStore_Proje.Applications.AuthorOperations.Queries.GetAuthorById;
using TestSetup;
using Xunit;

namespace Applications.AuthorOperations.Queries.GetAuthorById
{
    public class GetAuthorByIdQueryValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void WhenInvalidAuthoridIsGiven_Validator_ShouldBeReturnError(int Authorid)
        {
            GetAuthorByIdQuery query = new GetAuthorByIdQuery(null,null);
            query.AuthorId = Authorid;

            GetAuthorByIdQueryValidator validator = new GetAuthorByIdQueryValidator();
            var result = validator.Validate(query);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidAuthorIdIsGiven_Validator_ShouldNotBeReturnError()
        {
            GetAuthorByIdQuery query = new GetAuthorByIdQuery(null,null);
            query.AuthorId = 1;

            GetAuthorByIdQueryValidator validator = new GetAuthorByIdQueryValidator();
            var result = validator.Validate(query);

            result.Errors.Count.Should().Equals(0);
        }


    }
}