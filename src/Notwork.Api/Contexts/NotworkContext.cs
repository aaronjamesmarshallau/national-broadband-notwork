using System;
using Microsoft.EntityFrameworkCore;
using Notwork.Api.Contexts.Models;
using Npgsql;

namespace Notwork.Api.Contexts
{
    public class NotworkContext : DbContext
    {
        public DbSet<Ping> Pings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var host = Environment.GetEnvironmentVariable("PGSQL_HOST") ?? "localhost";
            var port = Environment.GetEnvironmentVariable("PGSQL_PORT") ?? "5432";
            var username = Environment.GetEnvironmentVariable("PGSQL_USER") ?? "notwork";
            var password = Environment.GetEnvironmentVariable("PGSQL_PASS") ?? "test123";
            var database = Environment.GetEnvironmentVariable("PGSQL_DATABASE") ?? "notwork";

            var csb = new NpgsqlConnectionStringBuilder
            {
                Host = host,
                Port = int.Parse(port),
                Username = username,
                Password = password,
                Database = database,
            };

            optionsBuilder.UseNpgsql(csb.ToString())
                .UseSnakeCaseNamingConvention();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ping>()
                .Property(ping => ping.Timestamp)
                .HasConversion(
                    timestamp => timestamp,
                    timestamp => DateTime.SpecifyKind(timestamp, DateTimeKind.Utc)
                );
        }
    }
}