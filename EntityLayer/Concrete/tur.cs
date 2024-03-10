using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class tur
    {
        [Key]
        public int turno { get; set; }
        [StringLength(50)]
        public string ad { get; set; }
        public ICollection<kitap> Kitaps { get; set; }
    }
}
