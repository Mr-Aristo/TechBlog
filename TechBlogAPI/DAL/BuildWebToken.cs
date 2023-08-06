using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace TechBlogAPI.DAL
{
    public class BuildWebToken
    {
        public string CreateToken()
        {
            var bytes = Encoding.UTF8.GetBytes("thisismytokenkeycode");// bu anahter keyi program.cs icinde configure edip belirledigimiz key.
            SymmetricSecurityKey key = new SymmetricSecurityKey(bytes); //SymmetricSecurityKey parametre olarak byte alir.
            SigningCredentials credentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);//Burda iki par. gerekli biri keyt digeri algoritma turu
                                                                                                       //HmcSha256 en sik kullanilan tur. JWT sitesindede bu var.Farkli bir algoritmada kullanilabilir.
            JwtSecurityToken token = new JwtSecurityToken(issuer: "http://localhost",audience:"http://localhost",
                notBefore:DateTime.Now,expires:DateTime.Now.AddMinutes(1), signingCredentials: credentials); // olusturucu, kullanici,olusturulan token suandan itibaren gecerli,gecerlilik suresi (1dk)

            JwtSecurityTokenHandler handler= new JwtSecurityTokenHandler();

            return handler.WriteToken(token); // burdada tokeni yazdirdik. 
        }
    }
}
