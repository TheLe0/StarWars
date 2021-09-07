using API.Context;
using API.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository
{
    public class UserRepository
    {
        private StarWarsContext context;

        public UserRepository()
        {
            context = new();
        }

        public async Task<string> Create(string username, string password)
        {

            User user = new();

            user.Username = username;
            user.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(password);
            user.Role = RoleType.USER;

            context.User.Add(user);

            var affectedRows = await context.SaveChangesAsync();

            return (affectedRows > 0) ? user.GenerateToken() : string.Empty;
        }

        public async Task<string> Login(string username, string password)
        {
            if (username.Length > 0 && password.Length > 0)
            {
                var user = await context.User
                    .Where(s => s.Username == username)
                    .FirstOrDefaultAsync();

                var validatePassword = BCrypt.Net.BCrypt.EnhancedVerify(
                    password,
                    user.Password
                );

                if (validatePassword)
                {
                    return user.GenerateToken();
                }
            }
            return string.Empty;
        }

    }
}
