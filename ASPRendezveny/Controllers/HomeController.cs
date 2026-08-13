using ASPRendezveny.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Web;

namespace ASPRendezveny.Controllers
{
    public class HomeController(RendezvenyContext db) : Controller
    {
        public IActionResult Index()
        {
            return View(db.Rendezvenyek.Where(r => !r.Torolt).ToList());
        }

        public IActionResult UjRendezveny()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UjRendezveny(Rendezveny r)
        {
            db.Add(r);
            return SaveData();
        }

        public IActionResult RendezvenySzerk(uint id)
        {
            return View(db.Rendezvenyek.Find(id));
        }
        
        [HttpPost]
        public IActionResult RendezvenySzerk(Rendezveny r)
        {
            db.Update(r);
            return SaveData();
        }

        public IActionResult RendezvenyTorles(uint id)
        {
            try
            {
                var r = db.Rendezvenyek.Find(id);
                if (r == null)
                {
                    TempData["message"] = "Nem sikerült törölni";
                    return RedirectToAction(nameof(Index));
                }
                db.Rendezvenyek.Remove(r);
                return SaveData();
            } catch (Exception e)
            {
                TempData["message"] = "Nem sikerült törölni, mert " + e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        private IActionResult SaveData()
        {
            try
            {
                db.SaveChanges();
                TempData["message"] = HttpUtility.HtmlEncode("Sikeres mentés");
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException e)
            {
                TempData["message"] = HttpUtility.JavaScriptStringEncode(e.InnerException.Message);
            }
            return RedirectToAction(nameof(Index));

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
