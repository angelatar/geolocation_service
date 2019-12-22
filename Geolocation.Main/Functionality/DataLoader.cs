using Geolocation.Main.Interfaces;
using System.IO;
using System.Security.AccessControl;

namespace Geolocation.Main.Functionality
{
    public class DataLoader : IDataLoader
    {
        private readonly IRepositoryManager _repo;

        public DataLoader(IRepositoryManager repo)
        {
            _repo = repo;
        }

        public void LoadCountries(string path)
        {
            var fileInfo = new FileInfo(path);
            var accessControl = fileInfo.GetAccessControl();
            accessControl.AddAccessRule(new FileSystemAccessRule("Everyone", FileSystemRights.FullControl, AccessControlType.Allow));
            fileInfo.SetAccessControl(accessControl);

            _repo.Locations.ExecuteSqlQuery($"delete from public.\"Locations\"; copy \"Locations\" From '{path}' with csv header");
        }

        public void LoadBlocks(string pathIPv4, string pathIPv6)
        {
            var fileInfoIPv4 = new FileInfo(pathIPv4);
            var accessControlIPv4 = fileInfoIPv4.GetAccessControl();
            accessControlIPv4.AddAccessRule(new FileSystemAccessRule("Everyone", FileSystemRights.FullControl, AccessControlType.Allow));
            fileInfoIPv4.SetAccessControl(accessControlIPv4);

            var fileInfoIPv6 = new FileInfo(pathIPv6);
            var accessCorntrolIPv6 = fileInfoIPv6.GetAccessControl();
            accessCorntrolIPv6.AddAccessRule(new FileSystemAccessRule("Everyone", FileSystemRights.FullControl, AccessControlType.Allow));
            fileInfoIPv6.SetAccessControl(accessCorntrolIPv6);

            _repo.Locations.ExecuteSqlQuery($"delete from public.\"Blocks\"; copy \"Blocks\" From '{pathIPv4}' with csv header");
            _repo.Locations.ExecuteSqlQuery($"copy \"Blocks\" From '{pathIPv6}' with csv header");
        }
    }
}
