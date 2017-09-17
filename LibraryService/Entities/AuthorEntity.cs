using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryService.Entities
{
    [Table("Authors")]
    public class AuthorEntity
    {
        [Key]
        public int Id {get; set;}

        [Required, MaxLength(100), MinLength(3)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string MiddleName { get; set; }

        [Required, MaxLength(100), MinLength(3)]
        public string LastName { get; set; }

        private ICollection<BookEntity> _books;

        public virtual ICollection<BookEntity> Books {
            get { return _books ?? (_books = new Collection<BookEntity>()); }
            set { _books = value; }
        }
    }
}
