using LibraryService.Models;

namespace LibraryService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class LIbraryService : ILibraryService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }        

        public Book GetBook(int id)
        {
            Book book = new Book();
            book.Title = "Title of book";
            book.ISBN = "1234 1234 1234";
            book.BookId = id;
            return book;
        }
    }
}
