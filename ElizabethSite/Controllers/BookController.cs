using ElizabethLibrary.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace ElizabethLibrary.Controllers
{
    public class BookController : Controller
    {        
        public BookController()
        {
            proxy = new LibraryService.LibraryServiceClient();
        }

        private LibraryService.LibraryServiceClient proxy;

        public ActionResult Books()
        {
            
            var books = proxy.GetBooks();

            var bookModels = new List<BookViewModel>();

            foreach (LibraryService.Book book in books)
            {
                bookModels.Add(ConvertBookToModel(book));
            }

            return View(bookModels);
           
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var book = proxy.GetBook(id.GetValueOrDefault());
            
            if (book == null)
            {
                return HttpNotFound();
            }
            
            return View(ConvertBookToModel(book));
        }

        private BookViewModel ConvertBookToModel(LibraryService.Book book)
        {
            BookViewModel bookModel = new BookViewModel();
            bookModel.BookId = book.BookId;
            bookModel.ISBN = book.ISBN;
            bookModel.Title = book.Title;
            bookModel.author = ConvertAuthorToModel(proxy.GetAuthor(book.AuthorId));
            return bookModel;
        }

        private AuthorViewModel ConvertAuthorToModel(LibraryService.Author author)
        {
            AuthorViewModel authorModel = new AuthorViewModel();
            authorModel.AuthorId = author.AuthorID;
            authorModel.FirstName = author.FirstName;
            authorModel.LastName = author.LastName;
            return authorModel;
        }

    }
}