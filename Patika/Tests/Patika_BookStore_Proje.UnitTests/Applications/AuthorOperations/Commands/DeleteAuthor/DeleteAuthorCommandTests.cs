using System;
using System.Linq;
using FluentAssertions;
using Xunit;
using TestSetup;
using Patika_BookStore_Proje.DBOperations;
using Patika_AuthorStore_Proje.Applications.AuthorOperations.Commands.DeleteAuthor;

namespace Applications.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        public DeleteAuthorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }
        
        [Fact]
        public void WhenGivenAuthorIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
        {
            // Arrange (Hazırlık)
            DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
            command.AuthorId = 0;

            // Act & Assert (Çalıştırma - Doğrulama)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek yazar bulunamadı.");
        }

        [Fact]
        public void WhenGivenAuthorIdInDBAndHaveBooks_InvalidOperationException_ShouldBeReturn()
        {
            // Arrange (Hazırlık)
            DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
            command.AuthorId = 1;

            // Act & Assert (Çalıştırma - Doğrulama)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Önce yazarın kitapları silinmeli");
        }

        [Fact]
        public void WhenGivenAuthorIdInDBAndHaveNotBooks_Author_ShouldBeDeleted()
        {
            // Arrange (Hazırlık)
            DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
            command.AuthorId = 7;

            // Act (Çalıştırma)
            FluentActions.Invoking(() => command.Handle()).Invoke();

            // Assert (Doğrulama)
            var author = _context.Authors.SingleOrDefault(g=>g.Id == command.AuthorId);
            author.Should().BeNull();
        }
    }
}