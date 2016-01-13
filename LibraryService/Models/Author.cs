using System.Runtime.Serialization;

namespace LibraryService.Models
{
    [DataContract]
    public class Author
    {
        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public int AuthorID { get; set; }
    }
}
