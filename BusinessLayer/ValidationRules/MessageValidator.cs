using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator() {
            RuleFor(x => x.Receiver).NotEmpty().WithMessage("Alıcı Adresini Boş Bırakamazsınız.");
            
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Alanını Boş Bırakamazsınız.");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Mesaj Alanını Boş Bırakamazsınız.");
            RuleFor(x => x.Receiver).EmailAddress().WithMessage("Lütfen geçerli bir mail adresi girin. ");
            
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen En az 3 Karakter girişi yapın.");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Lütfen En fazla 50 Karakter girişi yapın.");
         
        }
    }
}
