using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Data;
using System;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;

        private readonly AllDBContext db;

        public AccountController(ILogger<AccountController> logger, AllDBContext dbContext)
        {
            _logger = logger;
            db = dbContext;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Users user)
        {
            if (ModelState.IsValid)
            {
                Users users = await db.Users
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.Login == user.Login && u.Password == user.Password);
                if (user != null)
                {

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(user);
        }

    }
}