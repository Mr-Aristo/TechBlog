using EntityLayer.Concrete;
using FluentValidation; // indirilmesi gereken ek app
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidate : AbstractValidator<Writer>// Validate islemleri icin abstaractValidator < dogrulamak istedigimiz entity> seklinde kullanmak zorundayiz/
    {
        public WriterValidate()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Имя не может быть пустым.");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Почта не может быть пустым.");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Пароль не может быть пустым.");

            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Вы должны вставить более 2 символов");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Вы не можете вставить более 150 символов");

            //Bu kisimda iki kere girilen parolanin eslesip eslesmedigini kontrol ettik.
           //Fakat Equal in icindeki x.WiriterMessage yerine tabloda yeni bir coulm olmali yada baska bire cozum dusunulmeli.
           //Ayria valid islemi basarisiz oldgunda yinede veri tabanina ekleme yapiyor
           // RuleFor(x => x.WriterPassword).Equal(x => x.WriterMail).WithMessage("Parola eslesmiyor");
        }

    }
}
