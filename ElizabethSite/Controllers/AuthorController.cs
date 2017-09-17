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
            _proxy = new LibraryService.LibraryServiceClient();
        }

        private readonly LibraryService.LibraryServiceClient _proxy;

        public ActionResult Authors()
        {
            var authors = _proxy.GetAuthors();

            var authorModels = new List<AuthorViewModel>();

            foreach (var author in authors)
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

            var author = _proxy.GetAuthor(id.GetValueOrDefault());

            if (author == null)
            {
                return HttpNotFound();
            }

            return View(ConvertAuthorToModel(author));
        }

        private BookViewModel ConvertBookToModel(LibraryService.Book book)
        {
            var bookModel = new BookViewModel
            {
                BookId = book.BookId,
                Isbn = book.ISBN,
                Title = book.Title
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
            var bookModels = new List<BookViewModel>();
            foreach (var book in author.Books)
            {
                bookModels.Add(ConvertBookToModel(book));
            }
            authorModel.Books = bookModels;
            return authorModel;
        }
    }
}