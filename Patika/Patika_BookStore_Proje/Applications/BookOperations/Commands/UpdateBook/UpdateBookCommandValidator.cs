using System;
using FluentValidation;

namespace Patika_BookStore_Proje.Applications.BookOperations.Commands.UpdateBook{

    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(command=> command.BookId).GreaterThan(0);
            RuleFor(command=> command.Model.GenreId).GreaterThan(0);
            RuleFor(command=> command.Model.Title).MinimumLength(4).When(x => x.Model.Title.Trim() != string.Empty);



        }
    }

}