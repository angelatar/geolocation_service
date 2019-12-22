namespace Geolocation.Main.Interfaces
{
    public interface IEntityBaseRepository<T> where T : class, new()
    {
        int ExecuteSqlQuery(string query);

        void Commit();
    }
}
