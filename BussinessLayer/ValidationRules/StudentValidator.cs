using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules
{
    public class StudentValidator:AbstractValidator<Student>
    {
        public StudentValidator() 
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("İsim boş geçilemez");
            RuleFor(x=>x.Name).MinimumLength(2).MaximumLength(20).WithMessage("İsim 2 karakter ile 20 karakter arasında olmalı");
            RuleFor(x=>x.Surname).NotEmpty().WithMessage("Soyisim geçilemez");
            RuleFor(x=>x.Surname).MinimumLength(2).MaximumLength(20).WithMessage("Soyisim 2 karakter ile 20 karakter arasında olmalı");
            RuleFor(x => x.Gmail).EmailAddress().WithMessage("Lütfen gerçek bir mail adresi giriniz.");
        }
    }
}
