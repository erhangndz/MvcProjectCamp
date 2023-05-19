using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator: AbstractValidator<Contact>
    {
        public ContactValidator() 
        {
        RuleFor(x=>x.Message).NotEmpty().WithMessage("Mesaj alanını boş bırakamazsınız.");
        RuleFor(x=>x.UserName).NotEmpty().WithMessage("Ad Soyad alanını boş bırakamazsınız.");
        RuleFor(x=>x.Subject).NotEmpty().WithMessage("Konu alanını boş bırakamazsınız.");
        RuleFor(x=>x.UserMail).NotEmpty().WithMessage("Mail alanını boş bırakamazsınız.");
        RuleFor(x=>x.UserName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapın.");
        RuleFor(x=>x.Subject).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapın.");
        RuleFor(x=>x.Subject).MaximumLength(3).WithMessage("Lütfen en fazla 30 karakter giriş yapın.");
        RuleFor(x=>x.Message).MinimumLength(3).WithMessage("Lütfen en az 10 karakter girişi yapın.");
        }
    }
}
