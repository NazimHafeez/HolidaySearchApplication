using HolidaySearchApplication.Repository;

namespace HolidaySearchApplication.DomainModel.Flight
{
    public class Flight: EntityBase
    {
        public int Id { get; set; }
        public string Airline { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int Price { get; set; }
        public DateOnly DepartureDate { get; set; }
    }
}