using FluentValidation;

namespace Patika_BookStore_Proje.Applications.AuthorOperations.Commands.UpdateAuthor{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(command => command.AuthorId).GreaterThan(0);
            RuleFor(command => command.Model.Ad).MinimumLength(2).When(x => x.Model.Ad.Trim() != string.Empty);
            RuleFor(command => command.Model.Soyad).MinimumLength(2).When(x => x.Model.Ad.Trim() != string.Empty);
            RuleFor(command => command.Model.DogumTarihi).NotEmpty();
        }
    }
}