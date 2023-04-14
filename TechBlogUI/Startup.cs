using BusinessLayer.Abstracts;
using BusinessLayer.Concrete;
using BusinessLayer.Container;
using DataAccessLayer.Abstaract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concretes;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechBlogUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }




        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //******************//
            services.AddDbContext<Context>();
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>();
            //RegisterUserController de yaptigimiz islemin hata almadan yapilmasi icin
            //Bu service leri eklemeliyiz.
            //******************//
            services.AddControllersWithViews();



            services.Dependencies(); //<=  services.AddScoped<IBlogService, BlogManager>();services.AddScoped<IBlogDal, EFBlogRepository>();


            // Bu kisim login controllerde kullandigimis HttpContext.Session icin.
            // services.AddSession(); //=> bu kismi login de baska bir yontem kullandigimiz icin iptal ettik.            

            services.AddMvc(config => //Bu kisim authorize islemleri icindir.
            {
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser() // Bu fonk kullaincinin  sisteme login olmasini kontrol eder
                .Build();

                config.Filters.Add(new AuthorizeFilter(policy));
            });


            //Butun projeyi authorize ettik. Baska bir sayfaya erisim saglamak istedigimizda sistem hata firlatiyor.
            //Bu hatayi onlemek ve tekrar login indexi dondurmek icin assasagidaki islemleri uyguladik.
            services.AddMvc();
            services.AddAuthentication(
                CookieAuthenticationDefaults.AuthenticationScheme
                ).AddCookie(x =>
                {
                    x.LoginPath = "/Register/Index";
                    x.LoginPath = "/Login/Index";

                });

        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //Error sayfasini Bu kisimda ekledik. Controllerde actiona parametre verdik. Assagidada parametre olarak errorun id sini yolladik.
            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1", "?code={0}"); // code yazan kisim bir sorgudur. ErrorPage controller/ Error1 func


            // app.UseSession(); // Burada da ConfigureServices icine ekledimizi sessionu uygulamaya kullandiriyoruz.


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication(); // Authentication (kimlik dogrulamasi) kullana bilmek icin burada bu fonksiyonu cagiriyoruz.

            app.UseRouting();

            app.UseAuthorization();//Kimlik yetkilendirmesidir.

            app.UseEndpoints(endpoints =>
            {
                //Bu endpoint area'yi belirlememiz icin kullandik. Bu kisim olmadan area icindeki viewlere ulasamayiz
                endpoints.MapControllerRoute( 
            name: "areas",
            pattern: "{area:exists}/{controller=Category}/{action=Index}/{id?}"

            );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Blog}/{action=Index}/{id?}");
            });
        }
    }
}
