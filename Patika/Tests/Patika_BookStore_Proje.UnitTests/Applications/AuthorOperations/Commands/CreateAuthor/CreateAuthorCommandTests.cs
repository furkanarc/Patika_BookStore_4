using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using Xunit;
using TestSetup;
using Patika_BookStore_Proje.DBOperations;
using Patika_BookStore_Proje.Entities;
using Patika_BookStore_Proje.Applications.AuthorOperations.Commands.CreateAuthor;

namespace Applications.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateAuthorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistAuthorAdSoyadIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            // Arrange (Hazırlık)
            var author = new Author() { Ad = "YazarAd", Soyad = "YazarSoyad" };
            _context.Authors.Add(author);
            _context.SaveChanges();
            CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);
            command.Model = new CreateAuthorModel() { Ad = author.Ad, Soyad = author.Soyad };

            // Act & Assert (Çalıştırma - Doğrulama)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Bu isimde bir yazar zaten mevcut.");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Author_ShoulBeCreated()
        {
            // Arrange
            CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);
            command.Model = new CreateAuthorModel() { Ad = "Yeni YazarAd", Soyad = "Yeni YazarSoyad", DogumTarihi = "01.01.2000" };

            // Act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            // Assert
            var author = _context.Authors.SingleOrDefault(a => a.Ad == command.Model.Ad && a.Soyad == command.Model.Soyad);
            author.Should().NotBeNull();
            author.DogumTarihi.Should().Be(command.Model.DogumTarihi);

        }
    }
}