using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Staff
    {
        [Key]
        public int StaffId { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Surname { get; set; }
        public string Gmail { get; set; }
        public string Password { get; set; }
        public bool Admin { get; set; }

        public ICollection<Operation> Operations { get; set; }
    }
}
