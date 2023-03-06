using System;
using System.Linq;
using FluentAssertions;
using Xunit;
using TestSetup;
using Patika_BookStore_Proje.DBOperations;
using Patika_BookStore_Proje.Entities;
using Patika_BookStore_Proje.Applications.GenreOperations.Commands.CreateGenre;

namespace Applications.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        public CreateGenreCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenAlreadyExistGenreTitleIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            // Arrange (Hazırlık)
            var genre = new Genre() { Name = "Yeni Genre" };
            _context.Genres.Add(genre);
            _context.SaveChanges();
            CreateGenreCommand command = new CreateGenreCommand(_context);
            command.Model = new CreateGenreModel() { Name = genre.Name };

            // Act & Assert (Çalıştırma - Doğrulama)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap türü zaten mevcut");
        }

        [Fact]
        public void WhenValidInputIsGiven_Genre_ShoulBeCreated()
        {
            // Arrange
            CreateGenreCommand command = new CreateGenreCommand(_context);
            command.Model = new CreateGenreModel() { Name = "Yeni GenreAd" };

            // Act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            // Assert
            var genre = _context.Genres.SingleOrDefault(g => g.Name == command.Model.Name);
            genre.Should().NotBeNull();
        }
    }
}