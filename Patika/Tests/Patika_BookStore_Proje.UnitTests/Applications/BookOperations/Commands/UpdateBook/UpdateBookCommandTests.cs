using System;
using FluentAssertions;
using Xunit;
using TestSetup;
using Patika_BookStore_Proje.Applications.BookOperations.Commands.UpdateBook;
using Patika_BookStore_Proje.DBOperations;
using System.Linq;
using Patika_BookStore_Proje.Entities;

namespace Applications.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        public UpdateBookCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenGivenBookIdIsNotInDB_InvalidOperationException_ShouldBeReturn()
        {
            // Arrange (Hazırlık)
            UpdateBookCommand command = new UpdateBookCommand(_context);
            command.BookId = 0;

            // Act & Assert (Çalıştırma - Doğrulama)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Geçersiz BookId");
        }

        [Fact]
        public void WhenGivenBookIdIsInDBAndBookAlreadyExist_InvalidOperationException_ShouldBeReturn()
        {
            // Arrange (Hazırlık)
            var book = new Book(){ Title = "KitapAd" };
            _context.Books.Add(book);
            _context.SaveChanges();
            UpdateBookCommand command = new UpdateBookCommand(_context);
            command.Model = new UpdateBookModel { Title = book.Title};
            command.BookId = 1;

            // Act & Assert (Çalıştırma - Doğrulama)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Bu isimde kitap zaten mevcut.");
        }

        [Fact]
        public void WhenGivenBookIdIsInDB_Book_ShouldBeUpdated()
        {
            UpdateBookCommand command = new UpdateBookCommand(_context);  
            command.Model = new UpdateBookModel(){Title="Güncellenmiş Kitap", GenreId=1};  
            command.BookId = 1;
            
            FluentActions.Invoking(()=> command.Handle()).Invoke();

            var book=_context.Books.SingleOrDefault(b=>b.Id == command.BookId);
            book.Should().NotBeNull();
            book.GenreId.Should().Be(command.Model.GenreId);
        }

        
    }
}