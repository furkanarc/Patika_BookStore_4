using FluentAssertions;
using Patika_BookStore_Proje.Applications.BookOperations.Commands.CreateBook;
using TestSetup;
using Xunit;

namespace Applications.BookOperations.Commands.CreateBook
{
    public class CreateBookCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("Simyacı", 0, 0, 0)]
        [InlineData("Simyacı", 0, 1, 1)]
        [InlineData("Simyacı", 100, 0, 0)]
        [InlineData("", 0, 0, 1)]
        [InlineData("", 0, 1, 0)]
        [InlineData("", 100, 0, 1)]
        [InlineData("", 100, 1, 0)]
        [InlineData("Sim", 100, 0, 1)]
        [InlineData("Sim", 100, 1, 0)]
        [InlineData("Sim", 0, 0, 1)]
        [InlineData("Sim", 0, 1, 0)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string title, int pageCount, int genreId, int authorId)
        {
            // Arrange
            CreateBookCommand command = new CreateBookCommand(null, null);
            command.Model = new CreateBookModel() { Title = title, PageCount = pageCount, PublishDate = System.DateTime.Now.Date.AddYears(-1), GenreId = genreId, AuthorId = authorId };

            // Act
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            var result = validator.Validate(command);

            //Assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenDateTimeEqualsNowIsGiven_Validator_ShouldBeReturnError()
        {
            CreateBookCommand command = new CreateBookCommand(null, null);
            command.Model = new CreateBookModel() { Title = "Yeni Kitap", PageCount = 100, PublishDate = System.DateTime.Now.Date, GenreId = 1, AuthorId = 1 };

            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            CreateBookCommand command = new CreateBookCommand(null, null);
            command.Model = new CreateBookModel() { Title = "Yeni Kitap", PageCount = 100, PublishDate = System.DateTime.Now.Date.AddYears(-1), GenreId = 1, AuthorId = 1};

            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Equals(0);
        }
    }
}