using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Yazar adını boş geçemezsiniz.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Yazar Soyadını boş geçemezsiniz.");
            RuleFor(x => x.Name).MaximumLength(20).MinimumLength(2).WithMessage("Yazar adı 3 karakter ile 20 karakter arasında olmalı!!");
            RuleFor(x => x.Surname).MaximumLength(30).MinimumLength(2).WithMessage("Yazar Soyadı 3 karakter ile 20 karakter arasında olmalı!!");
        }
    }
}
