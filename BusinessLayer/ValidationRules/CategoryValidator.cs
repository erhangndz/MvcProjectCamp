using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator: AbstractValidator<Category>
    {
        public CategoryValidator() 
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adını Boş Bırakamazsınız.");
            RuleFor(x=>x.CategoryDescription).NotEmpty().WithMessage("Açıklamayı Boş Bırakamazsınız.");
            RuleFor(x=>x.CategoryName).MinimumLength(3).WithMessage("En az 3 Karakter girişi yapın. ");
            RuleFor(x=>x.CategoryName).MaximumLength(20).WithMessage("20 Karakterden fazla  giriş yapamazsınız. ");
        }
    }
}
