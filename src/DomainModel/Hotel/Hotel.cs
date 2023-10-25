namespace HolidaySearchApplication.DomainModel.Hotel
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ArrivalDate { get; set; }
        public int PricePerNight { get; set; }
        public string[] LocalAirports { get; set; }
        public int Nights { get; set; }
    }
}


