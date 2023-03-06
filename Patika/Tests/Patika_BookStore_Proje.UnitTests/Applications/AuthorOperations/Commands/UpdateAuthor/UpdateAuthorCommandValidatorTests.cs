using FluentAssertions;
using Patika_BookStore_Proje.Applications.AuthorOperations.Commands.UpdateAuthor;
using TestSetup;
using Xunit;

namespace Applications.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [InlineData(0,"", "", "")]
        [InlineData(0,"Y", "Y", "01.01.2000")]
        [InlineData(0,"YazarAd", "", "")]
        [InlineData(0,"", "YazarSoyad", "")]
        [InlineData(0,"YazarAd", "YazarSoyad", "")]
        [InlineData(1,"", "", "")]
        [InlineData(1,"Y", "Y", "01.01.2000")]
        [InlineData(1,"YazarAd", "", "")]
        [InlineData(1,"", "YazarSoyad", "")]
        [InlineData(1,"YazarAd", "YazarSoyad", "")]
        [Theory]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int authorId, string ad, string soyad, string dogumTarihi)
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(null);
            command.Model = new UpdateAuthorModel() { Ad = ad, Soyad = soyad, DogumTarihi = dogumTarihi };
            command.AuthorId = authorId;

            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
        
        
        [InlineData(1,"YazarAd", "YazarSoyad", "01.01.2000")]
        [InlineData(1,"", "YazarSoyad", "01.01.2000")]
        [InlineData(1,"YazarAd", "Ya", "01.01.2000")]
        [InlineData(1,"", "", "01.01.2000")]
        [InlineData(1,"Ya", "Ya", "01.01.2000")]
        [Theory]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnErrors(int authorId, string ad, string soyad, string dogumTarihi)
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(null);
            command.Model = new UpdateAuthorModel() { Ad = ad, Soyad = soyad, DogumTarihi = dogumTarihi };
            command.AuthorId = authorId;

            UpdateAuthorCommandValidator validations = new UpdateAuthorCommandValidator();
            var result = validations.Validate(command);

            result.Errors.Count.Should().Be(0);
        }
    }
}