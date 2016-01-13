using ElizabethLibrary.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace ElizabethLibrary.Controllers
{
    public class AuthorController : Controller
    {
        public AuthorController()
        {
            proxy = new LibraryService.LibraryServiceClient();
        }

        private LibraryService.LibraryServiceClient proxy;

        public ActionResult Authors()
        {

            var authors = proxy.GetAuthors();

            var authorModels = new List<AuthorViewModel>();

            foreach (LibraryService.Author author in authors)
            {
                authorModels.Add(ConvertAuthorToModel(author));
            }

            return View(authorModels);

        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var author = proxy.GetAuthor(id.GetValueOrDefault());

            if (author == null)
            {
                return HttpNotFound();
            }

            return View(ConvertAuthorToModel(author));
        }

        private BookViewModel ConvertBookToModel(LibraryService.Book book)
        {
            BookViewModel bookModel = new BookViewModel();
            bookModel.BookId = book.BookId;
            bookModel.ISBN = book.ISBN;
            bookModel.Title = book.Title;
            return bookModel;
        }

        private AuthorViewModel ConvertAuthorToModel(LibraryService.Author author)
        {
            AuthorViewModel authorModel = new AuthorViewModel();
            authorModel.AuthorId = author.AuthorID;
            authorModel.FirstName = author.FirstName;
            authorModel.LastName = author.LastName;
            var books = proxy.GetBooksByAuthorID(author.AuthorID);
            List<BookViewModel> bookModels = new List<BookViewModel>();
            foreach (LibraryService.Book book in books)
            {
                bookModels.Add(ConvertBookToModel(book));
            }
            authorModel.books = bookModels;
            return authorModel;
        }
    }
}