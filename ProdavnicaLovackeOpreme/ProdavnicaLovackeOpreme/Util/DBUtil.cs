using Microsoft.EntityFrameworkCore;
using ProdavnicaLovackeOpreme.Models;
using System.Security.Cryptography;
using System.Text;

namespace ProdavnicaLovackeOpreme.DB
{
    public class DBUtil
    {
        public static ProdavnicaContext getContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProdavnicaContext>();
            optionsBuilder.UseMySql(ProdavnicaContext.ConnectionString, new MySqlServerVersion(new Version(8, 0, 36)));
            return new ProdavnicaContext(optionsBuilder.Options);
        }

        public static String hashPassword(String password)
        {
            using (var hash = SHA256.Create())
            {
                var byteArray = Encoding.UTF8.GetBytes(password);
                var hashedResult = hash.ComputeHash(byteArray);

                string securedPass = string.Concat(Array.ConvertAll(hashedResult, h => h.ToString("X2")));
                return securedPass;
            }
        }
    }
}
