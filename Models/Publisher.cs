using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Halastoan_Luca_l2.Models
{
    public class Publisher
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string PublisherName { get; set; }

        
        public ICollection<Book>? Books { get; set; }
    }
}
