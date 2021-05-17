namespace book_store_function.Services
{
    public interface IOpenLibraryApiService
    {
        string SearchBooks(string query);
        string GetBookDetailsByIsbn(string isbn);
        string GetBookDetailsByWork(string work);
    }
}
