using FluentValidation;
using Patika_BookStore_Proje.Applications.AuthorOperations.Commands.CreateAuthor;

namespace Patika_BookStore_Proje.Applications.AuthorOperations.Commands.CreateAuthor{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(query => query.Model.Ad).MinimumLength(2);
            RuleFor(query => query.Model.Soyad).MinimumLength(2);
        }
    }
}