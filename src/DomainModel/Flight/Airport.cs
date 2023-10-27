namespace HolidaySearchApplication.DomainModel.Flight
{
    public record Airport
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
