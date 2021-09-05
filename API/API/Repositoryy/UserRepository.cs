using API.Context;
using API.Models;
using System;

namespace API.Repositoryy
{
    public class UserRepository
    {
        private StarWarsContext context;

        public UserRepository()
        {
            context = new();
        }

        public Boolean Create(string username, string password)
        {
            try
            {
                User user = new();

                user.Username = username;
                user.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(password);
                user.Role = RoleType.USER;

                context.User.Add(user);
                context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
