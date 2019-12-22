namespace Geolocation.Main.Interfaces
{
    public interface IDataLoader
    {
        void LoadCountries(string path);
        void LoadBlocks(string pathIPv4, string pathIPv6);
    }
}
