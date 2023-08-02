using AutoMapper;
using WebApi.BookOperations.GetBookDetail;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;
using static WebApi.BookOperations.GetBooks.GetBooksQuery;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookDetailViewModel>().ForMember(dest=> dest.Genre, opt=>opt.MapFrom(src =>((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
        }

    }
}
