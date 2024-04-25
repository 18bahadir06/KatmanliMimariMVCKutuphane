using EntityLayer;
using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules
{
    public class GenreValidator:AbstractValidator<Genre>
    {
        public GenreValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Tür adını boş geçemezsiniz.");
            RuleFor(x => x.Name).MaximumLength(20).MinimumLength(2).WithMessage("Tür adı 20 karakter ile 3 karakter arasında olmalı!!");
        }
    }
}
