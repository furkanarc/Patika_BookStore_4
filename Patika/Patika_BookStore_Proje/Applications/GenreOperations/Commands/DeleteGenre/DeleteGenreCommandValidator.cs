using FluentValidation;

namespace Patika_BookStore_Proje.Applications.GenreOperations.Commands.DeleteGenre{
    public class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreCommandValidator()
        {
            RuleFor(command => command.GenreId).GreaterThan(0);
        }
    }
}