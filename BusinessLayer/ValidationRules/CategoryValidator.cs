using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Название категории должно быть определено!");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Описание категории должно быть определено!");
            RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage("Вы не можете вставить более 50 символов");
            RuleFor(x => x.CategoryName).MinimumLength(5).WithMessage("Вы должны вставить более 5 символов!");
        }
    }
}
