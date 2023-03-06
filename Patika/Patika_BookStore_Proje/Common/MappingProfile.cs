using AutoMapper;
using Patika_BookStore_Proje.Applications.BookOperations.Commands.CreateBook;
using Patika_BookStore_Proje.Applications.BookOperations.Queries.GetBookById;
using Patika_BookStore_Proje.Applications.BookOperations.Queries.GetBooks;
using Patika_BookStore_Proje.Applications.GenreOperations.Queries.GetGenreById;
using Patika_BookStore_Proje.Applications.GenreOperations.Queries.GetGenres;
using Patika_BookStore_Proje.Applications.AuthorOperations.Queries.GetAuthors;
using Patika_BookStore_Proje.Entities;
using Patika_BookStore_Proje.Applications.AuthorOperations.Commands.CreateAuthor;

namespace Patika_BookStore_Proje.Common{

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name)).ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Ad + " " + src.Author.Soyad));
            CreateMap<Genre,GenresViewModel>();
            CreateMap<Genre,GenreViewModel>();
            CreateMap<CreateAuthorModel, Author>();
            CreateMap<Author,AuthorViewModel>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Ad + " " + src.Soyad ));
        }
    }

}
