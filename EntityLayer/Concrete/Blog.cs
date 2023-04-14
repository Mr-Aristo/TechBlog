using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Blog
    {
        [Key]
        public int BlogiD { get; set; }
        public string BlogTitle { get; set; }
        public string BlogContent { get; set; }
        public string BlogThumpnailImage { get; set; } //Blogun kucuk image si 
        public string BlogImage { get; set; } //Blogun buyuk image si. Sunucuda yer kaplamamasi icin dosya yolu olarak tutacagiz.
        public DateTime? CreateDate { get; set; }
        public bool BlogStatus { get; set; }


        public  int CategoryID  { get; set; } //Blog table da Fk categoryid 
        public  Category Category  { get; set; }

        public int WriterID { get; set; } //Blog table da Fk writerid 
        public Writer Writer { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
