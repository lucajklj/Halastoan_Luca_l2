using System.ComponentModel.DataAnnotations;

namespace Halastoan_Luca_l2.Models
{
    public class Author
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        // Proprietate de navigație pentru colecția de cărți scrise de acest autor
        public ICollection<Book>? Books { get; set; }
    }
}