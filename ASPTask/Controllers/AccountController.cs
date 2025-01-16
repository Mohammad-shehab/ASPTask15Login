using System;
using ASPTask.Data;
using ASPTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace ASPTask.Controllers
{
    public class AccountController : Controller
    {
        private TaskDBContext db;

        public AccountController(TaskDBContext _db)
        {
            db = _db;
        }

        //-------------------------------------------------------------

        public IActionResult AllRoles()
        {
            return View(db.Roles);
        }

        public IActionResult AllUsers()
        {
            return View(db.Users);
        }


        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRole(Role yyy)
        {

            if (ModelState.IsValid)
            {
                db.Roles.Add(yyy);
                db.SaveChanges();
                return RedirectToAction("AllRoles");
            }
            return View(yyy);

        }

        //------------------------------------------------------------------
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Depts = new SelectList(db.Roles, "RoleId", "RoleName");

            return View();
        }

        [HttpPost]
        public IActionResult Register(User xxx)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(xxx);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Depts = new SelectList(db.Roles, "RoleId", "RoleName");
            return View(xxx);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User model)
        {
            
                var user = db.Users.Where(u => u.Email == model.Email && u.Password == model.Password).FirstOrDefault();

                if (user != null)
                {
                    return RedirectToAction("Welcome", new { id = user.UserId, email = user.Email, name = user.UserName });
                }
                ModelState.AddModelError("", "Invalid email or password");
            
            return View(model);
        }

        public IActionResult Welcome(Guid id, string email, string name)
        {
            ViewBag.UserId = id;
            ViewBag.Email = email;
            ViewBag.UserName = name;
            return View();
        }







    }
}

