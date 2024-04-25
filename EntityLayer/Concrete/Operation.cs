using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Operation
    {
        [Key]
        public int OperationId { get; set; }
        public DateTime BorrowDate { get; set; } //alış tarihi
        public DateTime ReturnDate { get; set; } //veriş tarihi
        public int BookId { get; set; }
        public virtual Book Books { get; set; }
        public int StudentId { get; set; }
        public virtual Student Students { get; set; }

        public int RecipientId { get; set; }
        public virtual Staff Recipient { get; set; }
        public int ReturnerId { get; set; }
        public virtual Staff Returner { get; set; }
    }
}
