using System.Runtime.Serialization;

namespace LibraryService.Models
{
    [DataContract]
    public class Book
    {
        [DataMember]
        public int BookId { get; set; }

        [DataMember]
        public string ISBN { get; set; }

        [DataMember]
        public int AuthorId { get; set; }

        [DataMember]
        public string Title { get; set; }
    }
}
