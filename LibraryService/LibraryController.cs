using LibraryService.Entities;
using LibraryService.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace LibraryService
{
    public class LibraryDataAccess
    {
        private readonly LibraryContext _context;

        public LibraryDataAccess()
        {
            Database.SetInitializer(new LibraryInitializer());
            _context = new LibraryContext();
        }

        public Book GetBook(int id)
        {
            var bookEntity = (from b in _context.Books
                              where b.Id == id
                              select b).Include(b=>b.Author).FirstOrDefault();

            if (bookEntity != null)
            {
                return EntityModelMapper.TranslateBookEntityToBook(bookEntity);
            }
            else
            {
                throw new System.Exception("Invalid book id");
            }
        }

        public IEnumerable<Book> GetBooks()
        {
            var bookEntities = (from b in _context.Books select b).Include(b=>b.Author).ToList();

            var books = new List<Book>();

            foreach (var bookEntity in bookEntities)
            {
                books.Add(EntityModelMapper.TranslateBookEntityToBook(bookEntity));
            }

            return books;
        }

        public Author GetAuthor(int id)
        {
            var authorEntity = _context.Authors.Where(a=> a.Id == id).Include(a=> a.Books).FirstOrDefault();

            if (authorEntity != null)
            {
                return EntityModelMapper.TranslateAuthorEntityToAuthor(authorEntity);
            }
            else
            {
                throw new System.Exception("Invalid author id");
            }
        }


        public IEnumerable<Author> GetAuthors()
        {
            var authorEntities = _context.Authors.Include(a=> a.Books).ToList();
            
            var authors = new List<Author>();

            foreach (var authorEntity in authorEntities)
            {
                authors.Add(EntityModelMapper.TranslateAuthorEntityToAuthor(authorEntity));
            }

            return authors;
        }
        public IEnumerable<Book> GetBooksByAuthorId(int id)
        {
            var bookEntities = _context.Books.Where(b => b.Id == id).Include(b=>b.Author).ToList();

            var books = new List<Book>();

            foreach (var bookEntity in bookEntities)
            {
                books.Add(EntityModelMapper.TranslateBookEntityToBook(bookEntity));
            }

            return books;
        }

        public BookEntity AddNewBook(Book book)
        {
            if (book.Author != null)
            {
                var bookEntity = new BookEntity();
                var authorEntity = _context.Authors.Find(book.Author.AuthorID);

                if (authorEntity == null)
                {
                    authorEntity = AddNewAuthor(book.Author);
                    book.Author.AuthorID = authorEntity.Id;
                }

                bookEntity = EntityModelMapper.TranslateBookToBookEntity(book, bookEntity, authorEntity);
                _context.Books.Add(bookEntity);
                _context.SaveChanges();
                return bookEntity;
            }
            throw new System.Exception("Invalid Author on book");
        }

        public AuthorEntity AddNewAuthor(Author author)
        {
            var authorEntity = _context.Authors.Find(author.AuthorID) ?? new AuthorEntity();

            authorEntity = EntityModelMapper.TranslateAuthorToAuthorEntity(author, authorEntity);
            _context.Authors.Add(authorEntity);
            _context.SaveChanges();
            return authorEntity;
        }

        public Book UpdateBook(Book book)
        {
            var bookEntity = (from b in _context.Books
                              where b.Id == book.BookId
                              select b).FirstOrDefault();
            if (bookEntity == null)
            {
                throw new System.Exception("Invalid Book sent to update.  Did you mean to add it instead.");
            }
            else
            {
                bookEntity.Author = (from a in _context.Authors
                                     where a.Id == book.Author.AuthorID
                                     select a).FirstOrDefault();
                bookEntity.ISBN = book.ISBN;
                bookEntity.Title = book.Title;
            }
            _context.SaveChanges();
            return book;
        }

        public Author UpdateAuthor(Author author)
        {
            var authorEntity = (from b in _context.Authors
                                where b.Id == author.AuthorID
                                select b).FirstOrDefault();
            if (authorEntity == null)
            {
                throw new System.Exception("Invalid Author sent to update.  Did you mean to add it instead.");
            }
            else
            {
                authorEntity.FirstName = author.FirstName;
                authorEntity.LastName = author.LastName;
            }
            _context.SaveChanges();
            return author;
        }
    }
}
