
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens; // 24. satirdaki TokenValidationParameters icin lib.
using System.Text;

namespace TechBlogAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //JSON Web Token config islemleri.
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
                x=>
                {
                    x.RequireHttpsMetadata = false;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = "http://localhost", // kim tarafindan olusturuluyor, localhost tarafiondadn 
                        ValidAudience = "http://localhost", // kim tarafindan kullanilacak.
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("thisismytokenkeycode")),//Parametre byte turunde olmali en az 128 bit olmali yanikey uzun olmali. Secilen algoritmaya gore byte uzunlugu farklilik gosterir
                                                                                                                    //Bunun icin Encodig kullandik.
                        //GetByte icinde json token icin bir anahtar kod belirledik. 
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero

                    };
                }); // Json token kullanimi icin gerekli ekleme


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}