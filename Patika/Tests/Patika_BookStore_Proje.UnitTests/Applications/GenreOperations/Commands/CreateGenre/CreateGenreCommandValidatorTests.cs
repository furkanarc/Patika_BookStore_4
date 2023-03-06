using FluentAssertions;
using Patika_BookStore_Proje.Applications.GenreOperations.Commands.CreateGenre;
using TestSetup;
using Xunit;

namespace Applications.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("Yen")]
        public void WhenInvalidInputIsGiven_Validator_ShouldBeReturnErrors(string name)
        {
            CreateGenreCommand command = new CreateGenreCommand(null);
            command.Model= new CreateGenreModel() { Name = name };

            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenInvalidInputIsGiven_Validator_ShouldNotBeReturnError()
        {
            CreateGenreCommand command = new CreateGenreCommand(null);
            command.Model= new CreateGenreModel(){ Name = "Yeni Genre"};

            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
        }
    }
}