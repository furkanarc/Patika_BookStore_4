using FluentAssertions;
using Patika_BookStore_Proje.Applications.AuthorOperations.Commands.CreateAuthor;
using TestSetup;
using Xunit;

namespace Applications.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("", "")]
        [InlineData("A", "")]
        [InlineData("", "S")]
        [InlineData("A", "S")]
        [InlineData(" ", " ")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string ad, string soyad)
        {
            // Arrange
            CreateAuthorCommand command = new CreateAuthorCommand(null, null);
            command.Model = new CreateAuthorModel()
            {
                Ad = ad,
                Soyad = soyad,
            };

            // Act
            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
            var result = validator.Validate(command);

            //Assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            CreateAuthorCommand command = new CreateAuthorCommand(null, null);
            command.Model = new CreateAuthorModel()
            {
                Ad = "Ad",
                Soyad = "Soyad"
            };

            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Equals(0);
        }
    }
}