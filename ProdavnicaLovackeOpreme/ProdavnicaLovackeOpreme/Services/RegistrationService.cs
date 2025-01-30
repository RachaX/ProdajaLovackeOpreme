using ProdavnicaLovackeOpreme.DB;
using ProdavnicaLovackeOpreme.Models;
using System.Windows.Controls;

namespace ProdavnicaLovackeOpreme.Services
{
    public class RegistrationService : BaseService
    {
        public RegistrationService()
        {
        }

        public Boolean registerUser(String username, String password, String name, String surname, ComboBoxItem accType)
        {
            User user = new User() { Username = username, Password = DBUtil.hashPassword(password), Font = "Arial", Mode = 0, Theme = 0, Logged = 0 };

            String? accountType = accType.Content.ToString();

            accountType = accountType ?? string.Empty;

            if (accountType.Equals("Supplier") || accountType.Equals("Dobavljac"))
            {
                user.CompanyName = name;
                user.Jib = surname;
                user.Type = "Supplier";
            }
            else if (accountType.Equals("Manager") || accountType.Equals("Poslovodja")) 
            {
                user.Name = name;
                user.Surname = surname;
                user.Type = "Manager";
            }
            else if(accountType.Equals("Salesman") || accountType.Equals("Prodavac"))
            {
                user.Name = name;
                user.Surname = surname;
                user.Type = "Salesman";
            }
            else
            {
                return false;
            }
            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }
    }
}
