using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [StringLength(150)]
        public string Name { get; set; }
        public int Pages { get; set; }

        public int AuthorId { get; set; }
        public virtual Author Author  { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genres { get; set; }
        public double Score { get; set; }
        public string Photo { get; set; }

        public ICollection<Operation> Operations { get; set; }
    }
}
