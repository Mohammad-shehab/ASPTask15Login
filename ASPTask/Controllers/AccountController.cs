using System;
using ASPTask.Data;
using ASPTask.Models;
using ASPTask.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
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
            return View(db.Users.Include(u => u.Role));
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




        public IActionResult Registerconf()
        {
            ViewBag.Depts = new SelectList(db.Roles, "RoleId", "RoleName");

            return View();
        }
        [HttpPost]
        public IActionResult Registerconf(RegisterViewModel xxx)
        {
            User em = new User
            {
                UserName = xxx.UserName,
                Email = xxx.Email,
                Password = xxx.Password,
                RoleId = xxx.RoleId
            };

            if (ModelState.IsValid)
            {
                db.Users.Add(em);
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
            
                var user = db.Users.Include(x=>x.Role).Where(u => u.Email == model.Email && u.Password == model.Password).FirstOrDefault();

                if (user != null)
                {
                    return RedirectToAction("Welcome", new { id = user.UserId, email = user.Email, name = user.UserName,Role=user.Role.RoleName });
                }
                ModelState.AddModelError("", "Invalid email or password");
            
            return View(model);
        }

        public IActionResult Welcome(Guid id, string email, string name,string role)
        {
            ViewBag.UserId = id;
            ViewBag.Email = email;
            ViewBag.UserName = name;
            ViewBag.Role = role;

            return View();
        }


        [HttpGet]
        public IActionResult Loginv()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Loginv(LoginViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }
        //    var user = db.Users.Include(x => x.Role).FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

        //    if (user != null)
        //    {
        //        return RedirectToAction("Welcomev", new { id = user.UserId });
        //    }
        //    ModelState.AddModelError("", "Invalid email or password");

        //    return View(model);
        //}


        public IActionResult Welcomev(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = db.Users.Include(x => x.Role).FirstOrDefault(u => u.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }





        [HttpPost]
        public IActionResult Loginv(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = db.Users.Include(x => x.Role).FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

            if (user != null)
            {
                // Add session
                HttpContext.Session.SetString("UserId", user.UserId.ToString());
                HttpContext.Session.SetString("UserName", user.UserName);

                return RedirectToAction("Index", "Product");
            }
            ModelState.AddModelError("", "Invalid email or password");

            return View(model);
        }





    }
}

