using ApplicationCore.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        public DbSet<Answer> Answers{ get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Survey> Surveys { get; set;}
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Data Source=REIWAI;Initial Catalog=DocumentKeeper;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-GJUV1PHO;Initial Catalog=Survey;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}
