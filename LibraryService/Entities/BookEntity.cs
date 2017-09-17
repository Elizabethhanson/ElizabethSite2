using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryService.Entities
{
    [Table("Books")]
    public class BookEntity
    {
        public BookEntity()
        {
            Author = new AuthorEntity();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string ISBN { get; set; }

        [Required, MaxLength(200), MinLength(5)]
        public string Title { get; set; }

        [ForeignKey("AuthorId")]
        public virtual AuthorEntity Author { get; set; }

        public int AuthorId { get; set; }
    }
}
