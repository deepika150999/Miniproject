using AirTicketMiniProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirTicketMiniProject.Controllers
{
    public class PaymentController : Controller
    {
       private readonly FLightTicketContext _db;
        private readonly ISession session;
        public PaymentController(FLightTicketContext db, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;

            session = httpContextAccessor.HttpContext.Session;
        }
        public ActionResult passenger()
        {
            return View(_db.Passengers.ToList());
        }
        public IActionResult create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult create(Payment pay)
        {
            _db.Payments.Add(pay);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int Id)
        {
            Payment pas = _db.Payments.Find(Id);

            return View(pas);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Payment pa = _db.Payments.Find(id);
            return View(pa);

        }
        [HttpPost]
        public IActionResult Edit(Payment pay)
        {
            _db.Payments.Update(pay);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Payment f = _db.Payments.Find(id);
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
