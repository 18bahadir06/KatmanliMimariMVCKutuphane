using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Info { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
