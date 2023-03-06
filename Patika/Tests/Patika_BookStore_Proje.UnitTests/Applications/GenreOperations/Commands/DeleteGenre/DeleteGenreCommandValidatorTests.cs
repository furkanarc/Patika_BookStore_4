using FluentAssertions;
using Patika_BookStore_Proje.Applications.GenreOperations.Commands.DeleteGenre;
using TestSetup;
using Xunit;

namespace Applications.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void WhenInvalidGenreIdisGiven_Validator_ShouldBeReturnErrors(int genreId)
        {
            DeleteGenreCommand command = new DeleteGenreCommand(null);
            command.GenreId = genreId;

            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidGenreIdisGiven_Validator_ShouldNotBeReturnError()
        {
            DeleteGenreCommand command = new DeleteGenreCommand(null);
            command.GenreId = 1;

            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Equals(0);
        }
    }
}