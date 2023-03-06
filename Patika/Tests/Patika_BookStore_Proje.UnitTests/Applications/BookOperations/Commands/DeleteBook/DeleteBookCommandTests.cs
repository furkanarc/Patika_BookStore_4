using System;
using System.Linq;
using FluentAssertions;
using Xunit;
using TestSetup;
using Patika_BookStore_Proje.Applications.BookOperations.Commands.DeleteBook;
using Patika_BookStore_Proje.DBOperations;

namespace Applications.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        public DeleteBookCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void  WhenGivenBookIdIsNotInDB_InvalidOperationException_ShouldBeReturn()
        {
            // Arrange (Hazırlık)
            DeleteBookCommand command = new DeleteBookCommand(_context);
            command.BookId = 0;

            // Act & Assert (Çalıştırma - Doğrulama)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek kitap bulunamadı.");
        }

        [Fact]
        public void WhenGivenBookIdIsInDB_Book_ShouldBeDeleted()
        {
            // Arrange (Hazırlık)
            DeleteBookCommand command = new DeleteBookCommand(_context);
            command.BookId = 1;

            // Act (Çalıştırma)
            FluentActions.Invoking(() => command.Handle()).Invoke();

            // Assert (Doğrulama)
            var book = _context.Books.SingleOrDefault(b => b.Id == command.BookId);
            book.Should().BeNull();
        }
    }
}