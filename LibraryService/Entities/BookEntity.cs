using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryService.Entities
{
    [Table("Books")]
    public class BookEntity
    {
        [Key]
        public int BookEntityId { get; set; }
        public string ISBN { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
    }
}
