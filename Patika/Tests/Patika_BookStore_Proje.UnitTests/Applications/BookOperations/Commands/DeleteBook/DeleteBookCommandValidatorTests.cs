using FluentAssertions;
using Patika_BookStore_Proje.Applications.BookOperations.Commands.DeleteBook;
using TestSetup;
using Xunit;

namespace Applications.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void WhenInvalidBookIdIsGiven_Validator_ShouldBeReturnError(int bookId)
        {
            DeleteBookCommand command = new DeleteBookCommand(null);
            command.BookId = bookId;

            DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidBookIdIsGiven_Validator_ShouldNotBeReturnError()
        {
            DeleteBookCommand command = new DeleteBookCommand(null);
            command.BookId = 1;

            DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Equals(0);
        }
    }
}