using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LMS
{
    public class LMSContext : DbContext
    {
        public DbSet<User>? Users { get; set; }
        public DbSet<Course>? Courses { get; set; }
        public DbSet<Score>? Scores { get; set; }
        public LMSContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(s => s.UserName);
            modelBuilder.Entity<Course>().HasKey(s => s.CourseID);
            modelBuilder.Entity<Score>().HasNoKey();
        }

        public const string ConnectString = @"Data Source=KAZUHA\MSSQLSERVER1;Initial Catalog=LMSdb;User ID=sa;Password=123456";


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectString);
            optionsBuilder.UseLoggerFactory(GetLoggerFactory());
        }
        private ILoggerFactory GetLoggerFactory()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(builder =>
                    builder.AddConsole()
                           .AddFilter(DbLoggerCategory.Database.Command.Name,
                                    LogLevel.Information));
            return serviceCollection.BuildServiceProvider()
                    .GetService<ILoggerFactory>();
        }
    }
}


