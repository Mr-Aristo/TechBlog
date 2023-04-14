using BusinessLayer.Abstracts;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstaract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.EntityFrameworkRepos;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Container
{
    public static class ContainerDependency
    {
        //Bu kisim start upta yer kaplamamasi ve kodun okunabilir olmasi icin olusuturuldu.
        //Bu classi start up da cagirip yine startup da bulunan IServiceCollecton objesini
        //buradaki fonksiyonumuza parametre olarak gonderiyoruz.

        //ContainerDependency cd = new ContainerDependency();
        //cd.Dependencies(services); 
        //Yukaridaki yapiyi startup icinde kullandik. Fakat new lemeden ve direkt olarak fonksiyona ulasmak istedigimiz icin classimizi ve 
        //fonksiyonumuzu static yaptik.Fakat start up icinde fonksiyounumuzu bulamadik. Bunun sebebi parametremizin this anahtar kelimesi ile olmamasi
        //this bir nevi referans gostermemize yarayan kelime. startup icinde service.Dependencies seklinde kullandik. 
        public static void Dependencies(this IServiceCollection services)
        {
            services.AddScoped<IBlogService, BlogManager>();
            services.AddScoped<IAboutService,AboutManager>();
            services.AddScoped<ICategoryService,CategoryManager>();
            services.AddScoped<ICommentService,CommentManager>();
            services.AddScoped<IContactService,ContactManager>();
            services.AddScoped<IMessageService,MessageManager>();
            services.AddScoped<INewsLetterService,NewsLetterManager>();
            services.AddScoped<IWriterService,WriterManager>();
            services.AddScoped<INotificationService,NotificationManager>();
            services.AddScoped<IAdminService,AdminManager>();
           
            services.AddScoped<IBlogDal, EFBlogRepository>();
            services.AddScoped<IAboutDal, EFAboutRepository>();
            services.AddScoped<ICategoryDal, EFCategoryRepository>();
            services.AddScoped<ICommentDal, EFCommentRepository>();
            services.AddScoped<IContactDal, EFContactRepository>();
            services.AddScoped<IMessageDal, EFMessageRepository>();
            services.AddScoped<INewsLetterDal, EFNewsLetterRepository>();
            services.AddScoped<IWriterDal, EFWriterRepository>();
            services.AddScoped<INotificationDal, EFNotificationRepository>();
            services.AddScoped<IAdminDal, EFAdminRepository>();


        }
    }
}
