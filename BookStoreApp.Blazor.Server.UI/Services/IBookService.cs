using BookStoreApp.Blazor.Server.UI.Services.Base;

namespace BookStoreApp.Blazor.Server.UI.Services
{
    public interface IBookService
    {
        Task<Response<List<BookReadOnlyDto>>> GetAuthors();
        Task<Response<BookDetailsDto>> Get(int id);
        Task<Response<BookUpdateDto>> GetAuthorForUpdate(int id);

        Task<Response<int>> CreateAuthor(BookCreateDto author);
        Task<Response<int>> EditAuthor(int id, BookUpdateDto author);
        Task<Response<int>> Delete(int authorId);
    }

}
