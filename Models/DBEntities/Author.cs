using System.ComponentModel.DataAnnotations;

namespace OnlineLibrary.Models.DBEntities
{
    public class Author
    {       
            
        public Author()
        {
            this.Books = new HashSet<Book>();
        }

        public int AuthorId { get; set; }

        [Required]
        public string? Name { get; set; }

        public ICollection<Book>? Books { get; set; }
    }
}
