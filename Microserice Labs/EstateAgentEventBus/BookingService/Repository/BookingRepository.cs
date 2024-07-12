using BookingService.Infrastructure;
using BookingService.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BookingContext _context;

        public BookingRepository(BookingContext context)
        {
            _context = context;
        }

        public async Task<List<Booking>> GetBookingsAsync()
        {
            var bookings = await _context.Bookings.ToListAsync();
            return bookings;
        }

        public async Task<Booking> GetBookingByIdAsync(int bookingid)
        {
            var bookings = await _context.Bookings.SingleOrDefaultAsync(b => b.Id == bookingid);
            return bookings;
        }

        public async Task<Booking> AddBookingAsync(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task<IResult> UpdateBookingAsync(Booking updateBooking)
        {
            Booking booking = await _context.Bookings.SingleOrDefaultAsync(b => b.Id == updateBooking.Id);

            if (booking is null) return Results.NotFound();

            booking.BuyerId = updateBooking.BuyerId;
            booking.PropertyId = updateBooking.PropertyId;
            booking.Time = updateBooking.Time;

            await _context.SaveChangesAsync();
            return Results.NoContent();
        }

        public async Task<IResult> DeleteBookingByBookingIdAsync(int bookingId, BookingContext context)
        {
            var booking = await _context.Bookings.SingleOrDefaultAsync(b => b.Id == bookingId);

            if (booking is null) return Results.NotFound();

            context.Bookings.Remove(booking);
            await context.SaveChangesAsync();
            return Results.NoContent();
        }

        public async Task<IResult> DeleteBookingsByPropertyIdAsync(int propertyId, BookingContext context)
        {
            var bookings = _context.Bookings.Where(b => b.PropertyId == propertyId).ToList();
            if (bookings is null || bookings.Count() == 0) return Results.NotFound();
            context.Bookings.RemoveRange(bookings);
            //await context.SaveChangesAsync();
            context.SaveChanges();
            return Results.NoContent();
        }

    }
}
