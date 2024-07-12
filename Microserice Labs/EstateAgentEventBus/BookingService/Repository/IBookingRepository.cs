using BookingService.Models;
using BookingService.Infrastructure;

namespace BookingService.Repository
{
    public interface IBookingRepository
    {
        Task<List<Booking>> GetBookingsAsync();
        Task<Booking> GetBookingByIdAsync(int bookingid);
        Task<Booking> AddBookingAsync(Booking booking);
        Task<IResult> UpdateBookingAsync(Booking booking);
        Task<IResult> DeleteBookingByBookingIdAsync(int bookingId, BookingContext context);
        Task<IResult> DeleteBookingsByPropertyIdAsync(int propertyId, BookingContext context);
    }
}
