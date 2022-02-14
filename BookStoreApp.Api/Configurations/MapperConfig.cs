using AutoMapper;
using BookStoreApp.Api.Data;
using BookStoreApp.Api.Models.Author;
using BookStoreApp.Api.Models.Book;
using BookStoreApp.Api.Models.User;

namespace BookStoreApp.Api.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<AuthorCreateDto, Author>().ReverseMap();
            CreateMap<AuthorUpdateDto, Author>().ReverseMap();
            CreateMap<AuthorReadOnlyDto, Author>().ReverseMap();

            CreateMap<BookCreateDto, Book>().ReverseMap();
            CreateMap<BookReadOnlyDto, Book>().ReverseMap();
            CreateMap<Book, BookReadOnlyDto>().ForMember(author => author.Authorname, author2 => author2.MapFrom(mapAuthor =>
                 $"{mapAuthor.Author.FirstName} {mapAuthor.Author.Lastname}")).ReverseMap();
            CreateMap<Book, BookDetailsDto>().ForMember(author => author.Authorname, author2 => author2.MapFrom(mapAuthor =>
                $"{mapAuthor.Author.FirstName} {mapAuthor.Author.Lastname}")).ReverseMap();

            CreateMap<ApiUser, UserDto>().ReverseMap();
        }
    }
}
