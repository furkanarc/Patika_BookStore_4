using System;
using System.Linq;
using FluentAssertions;
using Patika_BookStore_Proje.Applications.AuthorOperations.Commands.UpdateAuthor;
using Patika_BookStore_Proje.DBOperations;
using Patika_BookStore_Proje.Entities;
using TestSetup;
using Xunit;

namespace Applications.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        public UpdateAuthorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenGivenAuthorIdIsNotInDB_InvalidOperationException_ShouldBeReturn()
        {
            // Arrange (Hazırlık)
            UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
            command.AuthorId = 0;

            // Act & Assert (Çalıştırma - Doğrulama)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Geçersiz AuthorId.");
        }

        [Fact]
        public void WhenGivenAuthorIdIsInDBAndAuthorAlreadyExist_InvalidOperationException_ShouldBeReturn()
        {
            // Arrange (Hazırlık)
            var author = new Author() { Ad = "YazarAd", Soyad = "YazarSoyad", DogumTarihi = "01.01.2000" };
            _context.Authors.Add(author);
            _context.SaveChanges();
            UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
            command.Model = new UpdateAuthorModel { Ad = author.Ad , Soyad = author.Soyad, DogumTarihi = author.DogumTarihi };
            command.AuthorId = 1;

            // Act & Assert (Çalıştırma - Doğrulama)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Bu isimde yazar zaten mevcut.");
        }

        [Fact]
        public void WhenGivenAuthorIdIsInDBAndValidInputsAreGiven_Author_ShouldBeUpdated()
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
            command.Model = new UpdateAuthorModel() { Ad = "Güncellenmiş YazarAd", Soyad = "Güncellenmiş YazarSoyad", DogumTarihi = "01.01.2000" };
            command.AuthorId = 1;

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var author = _context.Authors.SingleOrDefault(a => a.Id == command.AuthorId);
            author.Should().NotBeNull();
            author.Ad.Should().Be(command.Model.Ad);
            author.Soyad.Should().Be(command.Model.Soyad);
            author.DogumTarihi.Should().Be(command.Model.DogumTarihi);
        }
    }
}