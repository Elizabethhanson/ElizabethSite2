using System.Collections.Generic;
using System.Runtime.Serialization;

namespace LibraryService.Models
{
    [DataContract]
    public class Author
    {
        public Author()
        {
            Books = new List<Book>();
        }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public int AuthorID { get; set; }

        [DataMember]
        public ICollection<Book> Books {get; set;}
    }
}
