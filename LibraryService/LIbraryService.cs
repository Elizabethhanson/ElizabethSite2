using LibraryService.Models;
using LibraryService.Entities;
using System.Linq;

namespace LibraryService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class LibraryService : ILibraryService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }        

        public Book GetBook(int id)
        {
            LibraryContext context = new LibraryContext();
            var bookEntity = (from b in context.Books
                              where b.BookId == id
                              select b).FirstOrDefault();
            if (bookEntity != null)
            {
                return EntityModelMapper.TranslateBookEntityToBook(bookEntity);
            }
            else
            { throw new System.Exception("Invalid book id"); }
        }
    }
}
