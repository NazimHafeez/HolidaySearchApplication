namespace HolidaySearchApplication.QueryModel
{
    public class HolidaySearch: ISearchBase
    {
        public string DepartingFrom { get; set; }
        public string TravellingTo { get; set; }
        public string DepartureDate { get; set; }
        public int Duration { get; set; }

    }
}
