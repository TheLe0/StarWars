using API.Context;
using API.Models;
using System.Linq;

namespace API.Repository
{
    public class UserRepository
    {
        private StarWarsContext context;

        public UserRepository()
        {
            context = new();
        }

        public string Create(string username, string password)
        {

            User user = new();

            user.Username = username;
            user.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(password);
            user.Role = RoleType.USER;

            context.User.Add(user);

            var affectedRows = context.SaveChanges();

            return (affectedRows > 0) ? user.GenerateToken() : string.Empty;
        }

        public string Login(string username, string password)
        {
            if (username.Length > 0 && password.Length > 0)
            {
                var user = context.User
                    .Where(s => s.Username == username)
                    .FirstOrDefault();

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
