using Microsoft.AspNetCore.Http;

namespace TechBlogUI.Models
{
    public class AddProfileImage
    {
        //Bu ekleme islemini entitiy den yapabilirdik fakat bir property de degisiklik yapmak istiyoruz
        // ve bunu enititye ytansitmak istemiyoruz. 
        public int WriterID { get; set; }
        public string WriterName { get; set; }
        public string WriterAbout { get; set; }

        public IFormFile WriterImage { get; set; }    //Degisiklik yapptigimiz property 
        //IFromFile Pc den herhangi bir yerden dosya secmemizi saglar.




        public string WriterMail { get; set; } // sisteme giris
        public string WriterPassword { get; set; }//parola
        public bool WriterStatus { get; set; }
    }
}
