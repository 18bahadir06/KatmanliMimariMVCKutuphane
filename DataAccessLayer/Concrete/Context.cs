using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context:DbContext
    {
        public DbSet<tur> turs { get; set; }
        public DbSet<yazar> yazars { get; set; }
        public DbSet<kitap> kitaps { get; set; }
        public DbSet<islem> islems { get; set; }
        public DbSet<ogrenci> ogrencis { get; set; }
    }
}
