namespace BookStoreApp.Blazor.Server.UI.Services.Base
{
    public class Response<T>
    {
        public string Message { get; set; }
        public string ValidationErrors { get; set; }
        public bool Success { get; set; }
        public T Data { get; set; }

        public static implicit operator Response<T>(Response<AuthorReadOnlyDto> v)
        {
            throw new NotImplementedException();
        }
    }
}
