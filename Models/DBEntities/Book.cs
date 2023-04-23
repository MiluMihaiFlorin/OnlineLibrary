using System.ComponentModel.DataAnnotations;

namespace OnlineLibrary.Models.DBEntities
{
    public class Book
    {

        public Book()
        {
            this.Authors = new HashSet<Author>();
            this.Categories = new HashSet<Category>();
            this.Loans = new HashSet<Loan>();
        }
        public int BookId { get; set; }

        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Publisher { get; set; }

        [Required]
        public int PublishYear { get; set; }

        [Required]
        [StringLength(13, MinimumLength = 13)]
        public string? ISBN { get; set; }

        [Required]
        public int Quantity { get; set; }

        public ICollection<Author>? Authors { get; set; }

        public ICollection<Category>? Categories { get; set; }

        public ICollection<Loan>? Loans { get; set; }

    }
}
