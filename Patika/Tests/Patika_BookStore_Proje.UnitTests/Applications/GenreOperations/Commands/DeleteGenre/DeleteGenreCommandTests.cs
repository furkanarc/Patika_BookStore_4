using System;
using System.Linq;
using FluentAssertions;
using Xunit;
using TestSetup;
using Patika_BookStore_Proje.Applications.GenreOperations.Commands.DeleteGenre;
using Patika_BookStore_Proje.DBOperations;


namespace Applications.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        public DeleteGenreCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }
        
        [Fact]
        public void WhenGivenGenreIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
        {
            // Arrange (Hazırlık)
            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            command.GenreId = 0;

            // Act & Assert (Çalıştırma - Doğrulama)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek kitap türü bulunamadı.");
        }

        [Fact]
        public void WhenGivenGenreIdInDB_Genre_ShouldBeDeleted()
        {
            // Arrange (Hazırlık)
            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            command.GenreId = 1;

            // Act (Çalıştırma)
            FluentActions.Invoking(() => command.Handle()).Invoke();

            // Assert (Doğrulama)
            var genre=_context.Genres.SingleOrDefault(g=>g.Id == command.GenreId);
            genre.Should().BeNull();
        }
    }
}