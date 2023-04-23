using System.ComponentModel.DataAnnotations;

namespace OnlineLibrary.Models.DBEntities
{
    public class Loan
    {
        public Loan()
        {
            this.Books = new HashSet<Book>();
            this.User = new User(); 
        }

        public int LoanId { get; set; }

        public int UserId { get; set; }
        

        [Required]
        public DateTime LoanDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public ICollection<Book>? Books{ get; set; }

        public User? User { get; set; }
    }
}
