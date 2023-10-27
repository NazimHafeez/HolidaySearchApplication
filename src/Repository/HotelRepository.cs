using HolidaySearchApplication.DomainModel.Hotel;

namespace HolidaySearchApplication.Repository
{
    public class HotelRepository : IRepository<Hotel>
    {
        private HashSet<Hotel> _hotels = new();

        public void AddRange(IEnumerable<Hotel> models)
        {
            _hotels.UnionWith(models);
        }

        public IEnumerable<Hotel> GetAll()
        {
            return _hotels;
        }
    }
}
