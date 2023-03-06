using FluentAssertions;
using Patika_BookStore_Proje.Applications.GenreOperations.Queries.GetGenreById;
using TestSetup;
using Xunit;

namespace Applications.GenreOperations.Queries.GetGenreById
{
    public class GetGenreByIdQueryValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void WhenInvalidGenreidIsGiven_Validator_ShouldBeReturnError(int genreid)
        {
            GetGenreByIdQuery query = new GetGenreByIdQuery(null, null);
            query.GenreId = genreid;

            GetGenreByIdQueryValidator validations = new GetGenreByIdQueryValidator();
            var result = validations.Validate(query);

            result.Errors.Count.Should().BeGreaterThan(0);
        }


        [Fact]
        public void WhenValidGenreidIsGiven_Validator_ShouldNotBeReturnError()
        {
            GetGenreByIdQuery query = new GetGenreByIdQuery(null, null);
            query.GenreId = 1;

            GetGenreByIdQueryValidator validations = new GetGenreByIdQueryValidator();
            var result = validations.Validate(query);

            result.Errors.Count.Should().Be(0);
        }
    }
}