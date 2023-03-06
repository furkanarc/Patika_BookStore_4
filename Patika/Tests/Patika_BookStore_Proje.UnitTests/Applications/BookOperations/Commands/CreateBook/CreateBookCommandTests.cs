using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using Xunit;
using TestSetup;
using Patika_BookStore_Proje.Applications.BookOperations.Commands.CreateBook;
using Patika_BookStore_Proje.DBOperations;
using Patika_BookStore_Proje.Entities;


namespace Applications.BookOperations.Commands.CreateBook
{
    public class CreateBookCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateBookCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            // Arrange (Hazırlık)
            var book = new Book() { Title = "Kitap"};
            _context.Books.Add(book);
            _context.SaveChanges();
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            command.Model = new CreateBookModel() { Title = book.Title };

            // Act & Assert (Çalıştırma - Doğrulama)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Bu isimde bir kitap zaten mevcut.");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Book_ShoulBeCreated()
        {
            // Arrange
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            command.Model = new CreateBookModel() { Title = "Yeni Kitap", PageCount = 100, PublishDate = new DateTime(1990, 01, 01), GenreId = 1, AuthorId = 1 };

            // Act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            // Assert
            var book = _context.Books.SingleOrDefault(b => b.Title == command.Model.Title);
            book.Should().NotBeNull();
            book.PageCount.Should().Be(command.Model.PageCount);
            book.PublishDate.Should().Be(command.Model.PublishDate);
            book.GenreId.Should().Be(command.Model.GenreId);
            book.AuthorId.Should().Be(command.Model.AuthorId);
        }
    }
}