using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class yazar
    {
        [Key]
        public int yazarno { get; set; }
        [StringLength(50)]
        public string ad { get; set; }
        [StringLength(50)]
        public string soyad  { get; set; }
        public ICollection<kitap> Kitaps { get; set; }
    }
}
