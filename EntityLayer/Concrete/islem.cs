using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class islem
    {
        [Key]
        public int islemno { get; set; }
        public DateTime atarih { get; set; }
        public DateTime vtarih { get; set; }
        public int kitapno { get; set; }
        public virtual kitap kitap{ get; set; }
        public int ogrno { get; set; }
        public virtual ogrenci ogrenci{ get; set; }

    }
}
