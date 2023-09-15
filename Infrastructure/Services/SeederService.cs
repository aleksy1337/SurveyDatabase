using ApplicationCore.Models;
using Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Services
{
    public class SeederService
    {
        public static void Seed(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            
            var dbContext = scope.ServiceProvider.GetService<ApplicationDbContext>();

            if (dbContext is null)
            {
                throw new Exception("Cannot get required services.");
            }

            dbContext.Database.Migrate();
            dbContext.Database.EnsureCreated();

            if (!dbContext.Users.Any())
            {
                // PASSWORD: Survey@1
                var user = new IdentityUser()
                {
                    Id = "735dcae8-55ff-41ea-84da-77153b313565",
                    UserName = "user1",
                    NormalizedUserName = "USER1",
                    Email = "user1@surveydatabase.com",
                    NormalizedEmail = "USER1@SURVEYDATABASE.COM",
                    EmailConfirmed = false,
                    PasswordHash = "AQAAAAIAAYagAAAAEEZXAd2LdZ6GwuUjGO3Q2WEz6umrcF57UcLFwxr7cbJL85cco/3VDyzNZlbdEf4Yuw==",
                    SecurityStamp = "6TXY3EZ5IWHT5DSR2C267BHRYWYXMAAU",
                    ConcurrencyStamp = "a443f99c-1620-4a42-871a-655c82897abe",
                    PhoneNumber = null,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                };

                dbContext.Add(user);
                dbContext.SaveChanges();
            }

            if (!dbContext.Surveys.Any())
            {
                var survey = new Survey()
                {
                    Title = "Testowa ankieta",
                    Status = ApplicationCore.Enums.SurveyStatus.Public,
                    UserId = "735dcae8-55ff-41ea-84da-77153b313565"
                };

                dbContext.Add(survey);
                dbContext.SaveChanges();
            }
        }
    }
}
