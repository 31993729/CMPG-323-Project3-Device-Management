using DeviceManagement_WebApp.GenericRepository;
using DeviceManagement_WebApp.Models;

namespace DeviceManagement_WebApp.Repository
{
    public interface IZoneRepository : IGenericRepository<Zone>
    {
        Zone GetZone();
    }
}
