using FluentAssertions;
using Patika_AuthorStore_Proje.Applications.AuthorOperations.Commands.DeleteAuthor;
using TestSetup;
using Xunit;

namespace Applications.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void WhenInvalidAuthorIdIsGiven_Validator_ShouldBeReturnError(int AuthorId)
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(null);
            command.AuthorId = AuthorId;

            DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidAuthorIdIsGiven_Validator_ShouldNotBeReturnError()
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(null);
            command.AuthorId = 1;

            DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Equals(0);
        }
    }
}