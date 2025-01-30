using Microsoft.Extensions.DependencyInjection;
using ProdavnicaLovackeOpreme.Models;

namespace ProdavnicaLovackeOpreme.Services
{
    public class UserService : BaseService
    {
        private IServiceProvider _serviceProvider;
        public UserService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public void saveUserChanges(int mode, int theme, string font)
        {
            User? user = _serviceProvider.GetRequiredService<Storage>().User;

            User? user2 = _context.Users.FirstOrDefault(u => u.UserId == user.UserId);
            
            if(user2.Mode != (sbyte)mode) 
                user2.Mode = (sbyte)mode;
            if(user2.Theme != (sbyte)theme)
                user2.Theme = (sbyte)theme;
            if(!user2.Font.Equals(font))
                user2.Font = font;

            _context.SaveChanges();
        }

        public void logUser(sbyte value)
        {
            User? user = _serviceProvider.GetRequiredService<Storage>().User;
            _context.Users.FirstOrDefault(u => u.UserId == user.UserId).Logged = value;
            _context.SaveChanges();
        }
    }
}
