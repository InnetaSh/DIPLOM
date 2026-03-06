using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globals.Models
{
    public class ContextBase<T> : DbContext where T : EntityBase
    {
        private NpgsqlConnectionStringBuilder npgsqlConnectionStringBuilder = null;
        private String TypeName => typeof(T).Name.Replace("Context", String.Empty);
        public DbSet<T> Values { get; set; }

        public ContextBase()
        {
            npgsqlConnectionStringBuilder = new NpgsqlConnectionStringBuilder();
            //npgsqlConnectionStringBuilder.Host = "host.docker.internal"; // при запуске из докера
            //npgsqlConnectionStringBuilder.Host = "localhost"; // при запуске без докера
            npgsqlConnectionStringBuilder.Host = "postgres"; // при запуске из докера с использованием docker-compose (подключение к базе в контейнере)
            npgsqlConnectionStringBuilder.Port = 5432;
            npgsqlConnectionStringBuilder.Database = $"{TypeName}db";
            npgsqlConnectionStringBuilder.Username = "postgres";
            npgsqlConnectionStringBuilder.Password = "postgrespw";
            npgsqlConnectionStringBuilder.SslMode = SslMode.Disable;


            //if (TypeName == "Offer")
            //  Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public ContextBase(DbContextOptions options) : base(options)
        {
            //if (TypeName == "Offer")
            //  Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (npgsqlConnectionStringBuilder == null) return;

            optionsBuilder.UseNpgsql(npgsqlConnectionStringBuilder.ConnectionString);

            var enableSensitive = Environment.GetEnvironmentVariable("ENABLE_SENSITIVE_LOGGING");
            var aspEnv = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if (string.Equals(enableSensitive, "true", StringComparison.OrdinalIgnoreCase)
                || string.Equals(aspEnv, "Development", StringComparison.OrdinalIgnoreCase))
            {
                optionsBuilder.EnableSensitiveDataLogging();
                optionsBuilder.EnableDetailedErrors();
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Ignore<EntityBase>();
            builder.Entity<T>().ToTable(TypeName);

            ModelBuilderConfigure(builder);
        }

        protected virtual void ModelBuilderConfigure(ModelBuilder builder) { }
    }
}
