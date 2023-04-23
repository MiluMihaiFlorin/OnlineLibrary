using System.ComponentModel.DataAnnotations;

namespace OnlineLibrary.Models.DBEntities
{
    public class Category
    {

        public Guid CategoryId { get; set; }

        [Required]
        public string? Name { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Book> Books { get;} = new List<Book>();

    }
}
