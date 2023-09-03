using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Feane.Models;
using Microsoft.AspNetCore.Mvc;

namespace Feane.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService bookingService;
        public BookingController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        #region Index
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Index(BookingModel model)
        {
            if (model.Day < DateTime.Now)
            {
                ModelState.AddModelError("Day", "This is wrong");
                return View();
            }

            Booking booking = new Booking
            {
                Id = model.Id,
                FullName = model.FullName,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                CreatedTime = model.CreatedTime,
                Day = model.Day,
                Time = model.Time,
                IsTwoPerson = model.IsTwoPerson
            };

            bookingService.Add(booking);
            return RedirectToAction("Index");
        }
        #endregion
    }
}
