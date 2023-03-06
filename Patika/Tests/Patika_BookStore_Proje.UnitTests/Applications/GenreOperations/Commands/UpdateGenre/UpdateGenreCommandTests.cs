using System;
using System.Linq;
using FluentAssertions;
using Patika_BookStore_Proje.Applications.GenreOperations.Commands.UpdateGenre;
using Patika_BookStore_Proje.DBOperations;
using Patika_BookStore_Proje.Entities;
using TestSetup;
using Xunit;

namespace Applications.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        public UpdateGenreCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenGivenGenreIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
        {
            // Arrange (Hazırlık)
            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            command.GenreId = 0;

            // Act & Assert (Çalıştırma - Doğrulama)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Geçersiz GenreId");
        }

        [Fact]
        public void WhenGivenGenreIdIsInDBAndGenreAlreadyExist_InvalidOperationException_ShouldBeReturn()
        {
            var genre = new Genre() { Name = "GenreAd", IsActive = true};
            _context.Genres.Add(genre);
            _context.SaveChanges();
            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            command.Model = new UpdateGenreModel() { Name = genre.Name , IsActive = genre.IsActive};
            command.GenreId = 1;

            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Bu isimde bir tür zaten mevcut.");
        }

        [Fact]
        public void WhenGivenGenreIdinDB_Genre_ShouldBeUpdated()
        {
            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            command.Model = new UpdateGenreModel() { Name = "Güncellenmiş GenreAd" , IsActive = true};
            command.GenreId = 1;

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var genre = _context.Genres.SingleOrDefault(g => g.Id == command.GenreId);
            genre.Should().NotBeNull();
            genre.Name.Should().Be(command.Model.Name);

        }
    }
}