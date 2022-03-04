using AutoMapper;
using Blazored.LocalStorage;
using BookStoreApp.Blazor.Server.UI.Services.Base;

namespace BookStoreApp.Blazor.Server.UI.Services
{
    public class BookService : BaseHttpService, IBookService
    {
        private IClient _client;
        private ILocalStorageService _localStorage;
        private readonly IMapper _mapper;

        public BookService(IClient client, ILocalStorageService localStorage, IMapper mapper) : base(client, localStorage)
        {
            _localStorage = localStorage;
            _mapper = mapper;
            _client = client;
        }

        public async Task<Response<List<BookReadOnlyDto>>> GetBooks()
        {
            Response<List<BookReadOnlyDto>> response;
            try
            {
                await GetBearerToken();
                var data = await _client.BooksAllAsync();
                response = new Response<List<BookReadOnlyDto>>()
                {
                    Data = data.ToList(),
                    Success = true
                };
            }
            catch (ApiException exception)
            {
                response = ConvertApiExceptions<List<BookReadOnlyDto>>(exception);
            }
            return response;
        }

        public async Task<Response<BookDetailsDto>> Get(int id)
        {
            Response<BookReadOnlyDto> response;
            try
            {
                await GetBearerToken();
                var data = await _client.BooksGETAsync(id);
                response = new Response<BookReadOnlyDto>
                {
                    Data = data,
                    Success = true
                };
            }
            catch (ApiException exception)
            {
                response = ConvertApiExceptions<BookReadOnlyDto>(exception);
            }
            return response;
        }

        public async Task<Response<BookUpdateDto>> GetBookForUpdate(int id)
        {
            Response<BookUpdateDto> response;
            try
            {
                await GetBearerToken();
                var data = await _client.BooksGETAsync(id);
                response = new Response<BookUpdateDto>
                {
                    Data = _mapper.Map<BookUpdateDto>(data),
                    Success = true
                };
            }
            catch (ApiException exception)
            {
                response = ConvertApiExceptions<BookReadOnlyDto>(exception);
            }
            return response;
        }

        public async Task<Response<int>> CreateBook(BookCreateDto author)
        {
            Response<int> response = new();
            try
            {
                await GetBearerToken();
                _client.BooksPOSTAsync(author);
            }
            catch (ApiException exception)
            {
                response = ConvertApiExceptions<int>(exception);
            }

            return response;
        }

        public async Task<Response<int>> EditBook(int id, BookUpdateDto author)
        {
            Response<int> response = new();
            try
            {
                await GetBearerToken();
                await _client.BooksPUTAsync(id, author);
            }
            catch (ApiException exception)
            {
                response = ConvertApiExceptions<int>(exception);
            }

            return response;
        }

        public async Task Delete(int authorId)
        {
            Response<int> response = new();
            try
            {
                await GetBearerToken();
                _client.BooksDELETEAsync(authorId);
            }
            catch (ApiException exception)
            {
                response = ConvertApiExceptions<int>(exception);
            }

            return response;
        }
    }
}
