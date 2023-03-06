using System;
using FluentValidation;

namespace Patika_BookStore_Proje.Applications.BookOperations.Queries.GetBookById{
    public class GetBookByIdQueryValidator : AbstractValidator<GetBookByIdQuery>
    {
        public GetBookByIdQueryValidator()
        {
            RuleFor(query => query.BookId).GreaterThan(0);
        }
    }
}