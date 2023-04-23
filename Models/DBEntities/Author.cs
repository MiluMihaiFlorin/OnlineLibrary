using System.ComponentModel.DataAnnotations;

namespace OnlineLibrary.Models.DBEntities
{
    public class Author
    {       
            
        public Guid AuthorId { get; set; }

        [Required]
        public string? Name { get; set; }

        public ICollection<Book>? Books { get; set; }
    }
}
