using System.Runtime.Serialization;

namespace LibraryService.Models
{
    [DataContract]
    public class Book
    {
        public Book()
        {
            Author = new Author();
        }

        [DataMember]
        public int BookId { get; set; }

        [DataMember]
        public string ISBN { get; set; }

        [DataMember]
        public Author Author { get; set; }

        [DataMember]
        public string Title { get; set; }


    }
}
