using AirTicketMiniProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AirTicketMiniProject.Controllers
{
    public class UserController : Controller
    {
        private readonly FLightTicketContext _db;
        private readonly ISession session;
        public UserController(FLightTicketContext db, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;

            session = httpContextAccessor.HttpContext.Session;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginPage t)
        {
            //LINQ - Language Integrety Quer
            var result = (from i in _db.LoginPages
                          where i.EmailId == t.EmailId && i.Password == t.Password
                          select i).SingleOrDefault();
            if (result != null)
            {
                return RedirectToAction("Flight");
            }
            return null;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(LoginPage lo)
        {
            _db.LoginPages.Add(lo);
            _db.SaveChanges();
            return RedirectToAction("login");
        }


        [HttpGet]
        public ActionResult Flight()
        {
            return View(_db.Flights.ToList());
        }
        public IActionResult Details(int Id)
        {
            Flight flat = _db.Flights.Find(Id);

            return View(flat);
        }
        //[HttpGet]
        //public IActionResult Book() 
        //{
        //    return View();
        //}
        [HttpGet]
        public IActionResult Book(string FlightNumber)
        {
            Book book = new Book();
            book.FlightNumber = Convert.ToInt32(FlightNumber);           
            return View(book);
        }
        [HttpPost]
        public IActionResult Booking(Book book) 
        {

            _db.Books.Add(book);
            _db.SaveChanges();
          

            return RedirectToAction("PassengerData","user", book);
        }
        [HttpGet]
        public IActionResult PassengerData(Book book)
        {
            List<Passenger> passengers = new List<Passenger>();
            for (var i = 0; i < book.NumberOfPassengers; i++)
            {
                Passenger pass = new Passenger();
                pass.BookingId = book.BookingId;
                passengers.Add(pass);
            }
            return View(passengers);
        }
        [HttpPost]
        public IActionResult Passenger(IEnumerable<AirTicketMiniProject.Models.Passenger> passengers)
        {                   
            foreach (var pass in passengers)
            {
                _db.Passengers.Add(pass);
                _db.SaveChanges();
            }

            return RedirectToAction("Create","Payment");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("");
        }


    }
}
