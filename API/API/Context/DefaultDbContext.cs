using API.Utils;
using Microsoft.EntityFrameworkCore;
using System;

namespace API.Context
{
    public abstract class DefaultDbContext : DbContext
    {
        private static readonly string Host = DbAddress(DBTypes.Host);
        private static readonly string User = DbAddress(DBTypes.User);
        private static readonly string DBname = DbAddress(DBTypes.DBname);
        private static readonly string Password = DbAddress(DBTypes.Password);
        private static readonly string Port = DbAddress(DBTypes.Port);
        protected static readonly string Schema = DbAddress(DBTypes.Schema);
        private enum DBTypes { Host, User, DBname, Password, Port, Schema };

        
        private static string DbAddress(DBTypes type)
        {
            DotEnvUtil env = new();

            return type switch
            {
                DBTypes.Host => env.EnvVars["DB_HOST"],
                DBTypes.Port => env.EnvVars["PORT_HOST"],
                DBTypes.DBname => env.EnvVars["DB_NAME"],
                DBTypes.User => env.EnvVars["DB_USER"],
                DBTypes.Schema => env.EnvVars["DB_SCHEMA"],
                DBTypes.Password => env.EnvVars["DB_PASSWORD"],
                _ => "",
            };
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseNpgsql(string.Format(
                    "Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer",
                    Host,
                    User,
                    DBname,
                    Port,
                    Password),
                    x => x.MigrationsHistoryTable("_ef_migration_history", Schema)
                )
                .UseLowerCaseNamingConvention();
    }
}