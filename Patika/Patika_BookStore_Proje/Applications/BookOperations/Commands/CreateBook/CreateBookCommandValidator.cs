using System;
using FluentValidation;

namespace Patika_BookStore_Proje.Applications.BookOperations.Commands.CreateBook{

    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(command => command.Model.GenreId).GreaterThan(0);
            RuleFor(command => command.Model.AuthorId).GreaterThan(0);
            RuleFor(command => command.Model.PageCount).GreaterThan(0);
            RuleFor(command => command.Model.PublishDate.Date).LessThan(DateTime.Now.Date);
            RuleFor(command => command.Model.Title).MinimumLength(4);
        }
    }

}