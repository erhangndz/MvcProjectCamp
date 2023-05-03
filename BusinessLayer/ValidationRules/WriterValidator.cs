using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {

        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adını Boş Bırakamazsınız.");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar Soyadını Boş Bırakamazsınız.");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Yazar Unvanını Boş Bırakamazsınız.");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("En az 2 Karakter girişi yapın. ");
            RuleFor(x => x.WriterSurname).MinimumLength(3).WithMessage("En az 3 Karakter girişi yapın.");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("50 Karakterden fazla  giriş yapamazsınız. ");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("50 Karakterden fazla  giriş yapamazsınız. ");
        }
    }
}
