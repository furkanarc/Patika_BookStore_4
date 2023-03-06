using FluentAssertions;
using Xunit;
using TestSetup;
using Patika_BookStore_Proje.Applications.BookOperations.Commands.UpdateBook;

namespace Applications.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(1, "", 0)]
        [InlineData(1, "Sim", 0)]
        [InlineData(1, "Sim", 1)]
        [InlineData(0, "", 0)]
        [InlineData(0, "", 1)]
        [InlineData(0, "Sim", 0)]
        [InlineData(0, "Sim", 1)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int bookId, string title, int genreId)
        {
            // Arrange
            UpdateBookCommand command = new UpdateBookCommand(null);
            command.Model = new UpdateBookModel() { Title = title, GenreId = genreId, };
            command.BookId = bookId;

            // Act
            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            var result = validator.Validate(command);

            //Assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData(1, "", 1)]
        [InlineData(1, "Yeni Kitap", 1)]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError(int bookId, string title, int genreId)
        {
            UpdateBookCommand command = new UpdateBookCommand(null);
            command.Model = new UpdateBookModel() { Title = title, GenreId = genreId };
            command.BookId = bookId;

            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Equals(0);
        }
    }
}