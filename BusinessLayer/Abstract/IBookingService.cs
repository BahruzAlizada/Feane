using EntityLayer.Concrete;
using System;


namespace BusinessLayer.Abstract
{
    public interface IBookingService 
    {
        List<Booking> GetBookings();
        void Add(Booking booking);
        void Delete(int id);
    }
}
