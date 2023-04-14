using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>                   
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Вы должны ввести название");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Вы должны ввести содержимое.");

            //dosya yolu farkli sekilde ekelenecek kursun ilerleyen bolumunde
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Вы должны ввести изображение");
            RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("Вы не можете вставить более 150 символов");
            RuleFor(x => x.BlogTitle).MinimumLength(5).WithMessage("Вы должны вставить более 5 символов");

        


        }

    }
}
