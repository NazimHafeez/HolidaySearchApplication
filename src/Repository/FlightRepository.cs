using HolidaySearchApplication.DomainModel.Flight;

namespace HolidaySearchApplication.Repository
{
    public class FlightRepository : IRepository<Flight>
    {
        private HashSet<Flight> flights = new();

        public void AddRange(IEnumerable<Flight> models)
        {
            flights.UnionWith(models);
        }

        public IEnumerable<Flight> GetAll()
        {
            return flights;
        }
    }
}
