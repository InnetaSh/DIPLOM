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
        private String TypeName => typeof(T).Name.Replace("Context", String.Empty);
        public DbSet<T> Values { get; set; }

        public ContextBase()
        {
            //if (TypeName == "User")
            //    Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            NpgsqlConnectionStringBuilder npgsqlConnectionStringBuilder = new NpgsqlConnectionStringBuilder();
            //npgsqlConnectionStringBuilder.Host = "host.docker.internal"; // при запуске из докера
            //npgsqlConnectionStringBuilder.Host = "localhost"; // при запуске без докера
            npgsqlConnectionStringBuilder.Host = "postgres"; // при запуске из докера с использованием docker-compose (подключение к базе в контейнере)
            npgsqlConnectionStringBuilder.Port = 5432;
            npgsqlConnectionStringBuilder.Database = $"{TypeName }db";
            npgsqlConnectionStringBuilder.Username = "postgres";
            npgsqlConnectionStringBuilder.Password = "postgrespw";
            npgsqlConnectionStringBuilder.SslMode = SslMode.Disable;

            optionsBuilder.UseNpgsql(npgsqlConnectionStringBuilder.ConnectionString);
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
