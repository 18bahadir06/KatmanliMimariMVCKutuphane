using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kitap adını boş geçemezsin");
            RuleFor(x => x.Pages).NotEmpty().WithMessage("Sayfa sayısını boş geçemezsin");
            RuleFor(x=>x.Name).MinimumLength(2).MaximumLength(100).WithMessage("Kitap adı 2 karakter ile 100 karakter arasında olabilir.");
        }
    }
}
