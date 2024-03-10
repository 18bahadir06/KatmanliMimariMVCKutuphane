using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class kitap
    {
        [Key]
        public int kitapno { get; set; }
        [StringLength(150)]
        public string ad { get; set; }
        public double puan { get; set; }
        public int sayfasayisi { get; set; }
        
        public int yazarno { get; set; }
        public virtual yazar yazar { get; set;}
        public int turno { get; set; }
        public virtual tur tur { get; set;}
        
        public ICollection<islem> islems{ get; set; }
    }
}
