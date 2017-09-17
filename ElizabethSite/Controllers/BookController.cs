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
            _proxy = new LibraryService.LibraryServiceClient();
        }

        private readonly LibraryService.LibraryServiceClient _proxy;

        public ActionResult Books()
        {
            var books = _proxy.GetBooks();

            var bookModels = new List<BookViewModel>();

            foreach (var book in books)
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

            var book = _proxy.GetBook(id.GetValueOrDefault());
            
            if (book == null)
            {
                return HttpNotFound();
            }
            
            return View(ConvertBookToModel(book));
        }

        private BookViewModel ConvertBookToModel(LibraryService.Book book)
        {
            var bookModel = new BookViewModel
            {
                BookId = book.BookId,
                Isbn = book.ISBN,
                Title = book.Title,
                Author = ConvertAuthorToModel(book.Author)
            };

            return bookModel;
        }

        private AuthorViewModel ConvertAuthorToModel(LibraryService.Author author)
        {
            var authorModel = new AuthorViewModel
            {
                AuthorId = author.AuthorID,
                FirstName = author.FirstName,
                LastName = author.LastName
            };

            return authorModel;
        }

    }
}