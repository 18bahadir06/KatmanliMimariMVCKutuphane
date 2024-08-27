using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules
{
    public class StaffValidator:AbstractValidator<Staff>
    {
        public StaffValidator() 
        {
            RuleFor(x => x.Name).NotEmpty()
                .MinimumLength(2)
                .MaximumLength(20).WithMessage("İsim 2 karakter ile 20 karakter arasında olmalı.");
            RuleFor(x => x.Surname).NotEmpty()
                .MinimumLength(2)
                .MaximumLength(20).WithMessage("Soyadı 2 karakter ile 20 karakter arasında olmalı.");
            RuleFor(x => x.Gmail).NotEmpty().EmailAddress()
                .WithMessage("Email adresi giriniz.");
            RuleFor(x => x.Password).NotEmpty().MinimumLength(8).MaximumLength(16)
                .WithMessage("Şifre 8 ila 16 karakter olmalıdır.")
                .Matches("[A-Z]").WithMessage("Şifreniz en az bir büyük harf içermelidir.")
                .Matches("[a-z]").WithMessage("Şifreniz en az bir küçük harf içermelidir.")
                .Matches("[0-9]").WithMessage("Şifreniz en az bir rakam içermelidir.");
        }
    }
}
