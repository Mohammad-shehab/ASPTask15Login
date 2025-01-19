using ASPTask.Data;
using ASPTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPTask.Controllers
{
    public class ProductController : Controller
    {
        private TaskDBContext db;

        public ProductController(TaskDBContext _db)
        {
            db = _db;
        }



        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserId") == null) {

                return RedirectToAction("Loginv", "Account");
            }

            var userName = HttpContext.Session.GetString("UserName");
            var userId = HttpContext.Session.GetString("UserId");

   
            ViewBag.UserId = userId;

            ViewBag.UserName = userName;
            return View(db.Products);
        }



       


        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product yyy)
        {

            if (ModelState.IsValid)
            {
                db.Products.Add(yyy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(yyy);

        }
    }
}
