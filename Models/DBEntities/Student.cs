using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineLibrary.Models.DBEntities
{
    public class Student
    {
        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName ="varchar(50)")]
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }

        public double CNP { get; set; }

    }
}
