using FluentValidation;

namespace Patika_BookStore_Proje.Applications.GenreOperations.Commands.CreateGenre{
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator()
        {
            RuleFor(command => command.Model.Name).MinimumLength(4);
        }
    }
}