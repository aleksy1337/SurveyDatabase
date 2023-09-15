using ApplicationCore.Enums;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Survey> Surveys { get; set;}
        public DbSet<Question> Questions { get; set; }
        public DbSet<SurveyAnswer> SurveyAnswers { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswers{ get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Survey>(builder =>
            {
                builder.HasKey(s => s.Id);
                
                // https://learn.microsoft.com/en-us/ef/core/modeling/value-conversions?tabs=data-annotations
                builder.Property(s => s.Status)
                       .HasConversion(
                           status => status.ToString(),
                           status => (SurveyStatus)Enum.Parse(typeof(SurveyStatus), status));

                builder.HasMany(s => s.Questions)
                       .WithOne(q => q.Survey);

                builder.HasMany(s => s.SurveyAnswers)
                       .WithOne(a => a.Survey);
            });

            builder.Entity<Question>(builder =>
            {
                builder.HasKey(q => q.Id);

                builder.HasOne(q => q.Survey)
                       .WithMany(s => s.Questions);

                builder.HasMany(q => q.QuestionAnswers)
                       .WithOne(a => a.Question);
            });

            builder.Entity<SurveyAnswer>(builder =>
            {
                builder.HasKey(a => a.Id);

                builder.HasOne(a => a.Survey)
                       .WithMany(s => s.SurveyAnswers);

                builder.HasOne(a => a.User)
                       .WithMany(u => u.SurveyAnswers);

                builder.HasMany(a => a.QuestionAnswers)
                       .WithOne(qa => qa.SurveyAnswer);
            });

            builder.Entity<QuestionAnswer>(builder =>
            {
                builder.HasKey(qa => qa.Id);

                builder.HasOne(qa => qa.Question)
                       .WithMany(q => q.QuestionAnswers);

                builder.HasOne(qa => qa.SurveyAnswer)
                       .WithMany(a => a.QuestionAnswers);
            });

            // https://stackoverflow.com/questions/40703615/the-entity-type-identityuserloginstring-requires-a-primary-key-to-be-defined
            base.OnModelCreating(builder);
            builder.Ignore<IdentityUser<string>>();
            builder.Ignore<User>();
        }
    }
}
