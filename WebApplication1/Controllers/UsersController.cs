using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using System.Linq;
using System.Net;
using Microsoft.VisualBasic;
using NuGet.Protocol.Plugins;
using System.Diagnostics;

namespace WebApplication1.Controllers
{
    public class UsersController : Controller
    {
        private readonly ILogger<UsersController> _logger;

        private readonly AllDBContext db;

        public UsersController(ILogger<UsersController> logger, AllDBContext dbContext)
        {
            _logger = logger;
            db = dbContext;
        }

        public ActionResult Index(string searchString)
        {
            var users = from m in db.Users select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                users = users.Where(s => s.Role.Contains(searchString));
            }

            return View(users);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(404);
            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return NotFound();
            }
            return View(users);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("ID,Login,Password,Role")] Users users)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(users);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(users);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(404);
            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return NotFound();
            }
            return View(users);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("ID,Login,Password,Role")] Users users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(users);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(404);
            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return NotFound();
            }
            return View(users);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Users users = db.Users.Find(id);
            db.Users.Remove(users);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}