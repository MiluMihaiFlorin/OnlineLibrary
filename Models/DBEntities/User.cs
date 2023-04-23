using System.ComponentModel.DataAnnotations;

namespace OnlineLibrary.Models.DBEntities
{
    public class User
    {
        public User()
        {
            this.Loans = new HashSet<Loan>();
        }

        public int UserId { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        public DateTime? Birthdate { get; set; }

        [Required]
        public string? Username{ get; set; }


        [Required]
        public string? Password { get; set; }

        public ICollection<Loan>? Loans { get; set; }
    }
}
