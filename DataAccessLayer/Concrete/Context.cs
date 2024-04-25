using EntityLayer;
using EntityLayer.Concrete;
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
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Staff> Staffs { get; set; }
    }
}
