using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules
{
    public class turValidator:AbstractValidator<tur>
    {
        public turValidator()
        {
            RuleFor(x=>x.ad).NotEmpty().WithMessage("Tür adını boş geçemezsiniz.");
            RuleFor(x => x.ad).MaximumLength(20).MinimumLength(2).WithMessage("Tür adı 20 karakter ile 3 karakter arasında olmalı!!");
        }
    }
}
