using System;
using System.Linq;
using FluentValidation;
using Patika_BookStore_Proje.Common;
using Patika_BookStore_Proje.DBOperations;

namespace Patika_BookStore_Proje.Applications.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(command => command.BookId).GreaterThan(0);
        }
    }
}