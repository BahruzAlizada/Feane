using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;

namespace BusinessLayer.Concrete
{
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal bookingDal;
        public BookingManager(IBookingDal bookingDal)
        {
            this.bookingDal = bookingDal;
        }
        public void Add(Booking booking)
        {
            bookingDal.Add(booking);
        }

        public void Delete(int id)
        {
            Booking booking = bookingDal.Get(x => x.Id == id);
            bookingDal.Delete(booking);
        }

        public List<Booking> GetBookings()
        {
            return bookingDal.GetAll();
        }
    }
}
