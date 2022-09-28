using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.GenericRepository;
using DeviceManagement_WebApp.Models;
using System.Linq;

namespace DeviceManagement_WebApp.Repository
{
        public class ZoneRepository : GenericRepository<Zone>, IZoneRepository
    {
        public ZoneRepository(ConnectedOfficeContext context) : base(context)
        {
        }

        public Zone GetZone()
        {
            return _context.Zone.OrderByDescending(Zone => Zone.ZoneId).FirstOrDefault();
        }
    }
}
