using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            using (var db = new ApplicationDbContext()) {
                ViewBag.CountryId = new SelectList(db.Countries.OrderBy(c => c.Name).ToList(), "Id", "Name");
                ViewBag.CityId = new SelectList(db.Cities.OrderBy(c => c.Name).ToList(),"Id","Name");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Contact(Feedback feedback)
        {
            try { 
                using (var db = new ApplicationDbContext())
                {
                    feedback.Id = Guid.NewGuid();
                    db.Feedbacks.Add(feedback);
                    db.SaveChanges();
                    return Json(new { success = true });
                }
            } catch(Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
            
        }

        private IDisposable ApplicationDbContext()
        {
            throw new NotImplementedException();
        }

        public ActionResult Kroki()
        {
            return PartialView();
        }
        
        public ActionResult KrokiYolunuGetir()
        {
            var yol = "/images/kroki.jpg";
            return Json(yol, JsonRequestBehavior.AllowGet);
        }
    }
}