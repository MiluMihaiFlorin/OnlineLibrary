using OnlineLibrary.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace OnlineLibrary.Models.DBEntities
{
    public class Loan
    {
        public Guid LoanId { get; set; }


                

        [Required]
        public DateTime LoanDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public ICollection<OnlineLibraryUser>? Users { get; set; }
        
        public ICollection<Book>? Books{ get; set; }
        

    }
}
