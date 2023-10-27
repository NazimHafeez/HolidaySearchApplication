namespace HolidaySearchApplication.Repository
{
    public interface IRepository<TModel> where TModel: EntityBase
    {
        IEnumerable<TModel> GetAll();
        void AddRange(IEnumerable<TModel> models);
    }
}
