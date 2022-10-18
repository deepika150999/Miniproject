using AirTicketMiniProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirTicketMiniProject.Controllers
{
    public class AdminController : Controller
    {
        private readonly FLightTicketContext _db;
        private readonly ISession session;
        public AdminController(FLightTicketContext db, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;

            session = httpContextAccessor.HttpContext.Session;
        }
        public ActionResult Flight()
        {
            return View(_db.Flights.ToList());
        }
        public IActionResult create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult create(Passenger passenger)
        {
            _db.Passengers.Add(passenger);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Passenger
            ()
        {
            return View(_db.Passengers.ToList());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Passenger pa = _db.Passengers.Find(id);
            return View(pa);

        }
        [HttpPost]
        public IActionResult Edit(Passenger pass)
        {
            _db.Passengers.Update(pass);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Passenger f = _db.Passengers.Find(id);
            return View(f);

        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Passenger pasn = _db.Passengers.Find(id);
            _db.Passengers.Remove(pasn);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
