using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Feane.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookingController : Controller
    {
        private readonly IBookingService bookingService;
        public BookingController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        #region Index
        public IActionResult Index(int page=1)
        {
            double take = 10;
            ViewBag.PageCount = Math.Ceiling(bookingService.GetBookings().Count() / take);
            ViewBag.CurrentPage = page;

            List<Booking> bookings = bookingService.GetBookings().OrderByDescending(x => x.Id).
                Skip((page - 1) * (int)take).Take((int)take).ToList();
            
            return View(bookings);
        }
        #endregion
    }
}
