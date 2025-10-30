using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Halastoan_Luca_l2.Models
{
    public class Book
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Book Title")]
        [Required]
        public string Title { get; set; }

    
        public int? AuthorID { get; set; }

       
        public Author? Author { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        [Range(0, 9999.99)]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishingDate { get; set; }

    
        public int? PublisherID { get; set; }
        public Publisher? Publisher { get; set; }

        public ICollection<BookCategory>? BookCategories { get; set; }
    }
}