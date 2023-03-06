using FluentValidation;

namespace Patika_BookStore_Proje.Applications.AuthorOperations.Queries.GetAuthorById{
    public class GetAuthorByIdQueryValidator : AbstractValidator<GetAuthorByIdQuery>
    {
        public GetAuthorByIdQueryValidator()
        {
            RuleFor(query => query.AuthorId).GreaterThan(0);
        }
    }
}