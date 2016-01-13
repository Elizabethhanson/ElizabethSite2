using System.Collections.Generic;

namespace ElizabethLibrary.Models
{
    public class BookViewModel
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public string ISBN { get; set; }

        public AuthorViewModel author { get; set; }

    }

    public class AuthorViewModel
    {
        public int AuthorId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IEnumerable<BookViewModel> books { get; set; }
    }
}