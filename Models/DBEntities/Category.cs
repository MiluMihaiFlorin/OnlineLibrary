using System.ComponentModel.DataAnnotations;

namespace OnlineLibrary.Models.DBEntities
{
    public class Category
    {

        public Category()
        {
            this.Books = new HashSet<Book>();
        }

        public int CategoryId { get; set; }

        [Required]
        public string? Name { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Book> Books { get;} = new List<Book>();

    }
}
