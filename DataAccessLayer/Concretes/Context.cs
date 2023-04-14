using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{ //Context sinifizda yuklemis oldugumuz identity kutuphanesinin icerdigi tablolari cagiracagiz. 
    public class Context : IdentityDbContext<AppUser, AppRole,int>// rol belirleme ve int kismi key degeri
    {   //bu class DbContext'in butun ozelliklerini kullanabilir.
        //AppUser entity icinde olan class. IdentityUser ile ilski kurmasi icin yani appuserin cloumn larini identityuser a eklenmesi icin
        //bu  sekilde tanimladik assagida ki gibi dataset ile degil.
        //mig_identity_add_appuser da aciklama var.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // connection string tanimlamak icin bole bir yapi kurduk 
        {
            optionsBuilder.UseSqlServer("server=.\\sqlexpress; Connect Timeout = 30 ; database=TechBlogDb; integrated security=true;TrustServerCertificate=True;");//Bu fonksiyon icin entitiyframework.core.sqlserver yuklenmesi gereklidir. 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .HasOne(x => x.SenderUser)
                .WithMany(y => y.WriterSender)
                .HasForeignKey(z => z.SenderID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Message>()
             .HasOne(x => x.RecieverUser)
             .WithMany(y => y.WriterReciver)
             .HasForeignKey(z => z.RecieverID)
             .OnDelete(DeleteBehavior.ClientSetNull);

            //identity clasini ekledigimiz icin mig eklerken hata aldik
            //Bu hatayi gidermek icin alltaki komutu yazdik.
            //hatanin ismi The entity type 'IdentityUserLogin<string>' requires a primary key to be defined. If you intended to use a keyless entity type, call 'HasNoKey' in 'OnModelCreating'

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }
        public DbSet<BlogRayting> BlogRayrings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Admin> Admins { get; set; }

        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }





    }
}
