using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryService.Entities
{
    [Table("Authors")]
    public class AuthorEntity
    {
        [Key]
        public int AuthorEntityId {get; set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
