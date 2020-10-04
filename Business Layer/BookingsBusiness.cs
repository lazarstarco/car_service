using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer;
using Data_Layer.Models;

namespace Business_Layer
{
    public class BookingsBusiness
    {
        private BookingsRepository bookingsRepository;
        public BookingsBusiness()
        {
            bookingsRepository = new BookingsRepository();
        }

        public List<Bookings> GetAllBookings()
        {
            return bookingsRepository.GetAllBookings();
        }


        public bool InsertBookings(Bookings bookings)
        {
            int result = 0;
            if (bookings != null)
            {
                result = bookingsRepository.InsertBookings(bookings);
            }
            return result > 0 ? true : false;
        }
        public bool UpdateBooking(string defect, int repaired, string id)
        {
            int result = 0;
            if (defect != null && (repaired == 0 || repaired == 1) && id.Length != 0)
            {
                result = bookingsRepository.UpdateBookings(defect, repaired, id.Split(new string[] { "." }, StringSplitOptions.None));
            }
            return result > 0 ? true : false;
        }
        public bool DeleteBookings(Bookings bookings)
        {
            int result = bookingsRepository.DeleteBookings(bookings);
            return result > 0 ? true : false;
        }
    }
}
