using BookingService.Repository;
using Events;
using DotNetCore.CAP;
//using System.Text.Json;
using Newtonsoft.Json;
using BookingService.Infrastructure;


namespace BookingService.DomainEventHandlers
{
    public class PropertyDeletedEventSubscriber: ICapSubscribe
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly BookingContext _bookingContext;

        public PropertyDeletedEventSubscriber(IBookingRepository bookingRepository, BookingContext bookingContext)
        {
            _bookingRepository = bookingRepository;
            _bookingContext = bookingContext;
        }

        [CapSubscribe("PropertyDeleted")]
        public async void Consumer(string content)
        {
            var property = JsonConvert.DeserializeObject<PropertyDeletedEvent>(content);
            //var dict = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(content);
            //string propertyId = dict["ValueKind"];
            await _bookingRepository.DeleteBookingsByPropertyIdAsync(property.PropertyId, _bookingContext);
        }
    }
 
}
