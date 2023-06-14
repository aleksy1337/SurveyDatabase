using ApplicationCore.Models;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace SurveyDatabase.API.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                // Sprawdź unikalność nazwy użytkownika
                var existingUser = _context.Users.FirstOrDefault(u => u.Username == user.Username);
                if (existingUser != null)
                {
                    ModelState.AddModelError("Username", "Nazwa użytkownika jest już zajęta.");
                    return View(user);
                }

                // Sprawdź unikalność adresu e-mail
                var existingEmail = _context.Users.FirstOrDefault(u => u.Email == user.Email);
                if (existingEmail != null)
                {
                    ModelState.AddModelError("Email", "Adres e-mail jest już używany.");
                    return View(user);
                }

                // Zapisz nowego użytkownika w bazie danych
                _context.Users.Add(user);
                _context.SaveChanges();

                return RedirectToAction("Login", "Account"); // Przekierowanie do strony logowania
            }

            return View(user);
        }
    }
}
