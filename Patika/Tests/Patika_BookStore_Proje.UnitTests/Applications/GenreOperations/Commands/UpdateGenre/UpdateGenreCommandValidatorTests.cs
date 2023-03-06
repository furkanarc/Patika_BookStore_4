using FluentAssertions;
using Patika_BookStore_Proje.Applications.GenreOperations.Commands.UpdateGenre;
using TestSetup;
using Xunit;

namespace Applications.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [InlineData(0,"G")]
        [InlineData(0,"Gen")]
        [InlineData(1,"G")]
        [InlineData(1,"Gen")]
        [Theory]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int genreId,string name)
        {
            UpdateGenreCommand command = new UpdateGenreCommand(null);
            command.Model = new UpdateGenreModel(){Name = name};
            command.GenreId = genreId;

            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [InlineData(1,"")]
        [InlineData(1,"Genre")]
        [Theory]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnErrors(int genreId,string name)
        {
            UpdateGenreCommand command = new UpdateGenreCommand(null);
            command.Model = new UpdateGenreModel(){Name = name};
            command.GenreId = genreId;

            UpdateGenreCommandValidator validations = new UpdateGenreCommandValidator();
            var result = validations.Validate(command);

            result.Errors.Count.Should().Be(0);
        }
    }
}