using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class ogrenci
    {
        [Key]
        public int ogrno { get; set; }
        [StringLength(50)]
        public string ad { get; set; }
        [StringLength(50)]
        public string soyad { get; set; }
        public DateTime dtarih { get; set; }
        public bool cinsiyet { get; set; }
        public string sinif { get; set; }
        public double puan { get; set; }
        public ICollection<islem> islems { get; set; }
    }
}
