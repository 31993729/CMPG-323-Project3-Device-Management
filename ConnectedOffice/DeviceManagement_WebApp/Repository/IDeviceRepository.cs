﻿using DeviceManagement_WebApp.GenericRepository;
using DeviceManagement_WebApp.Models;

namespace DeviceManagement_WebApp.Repository
{
    public interface IDeviceRepository : IGenericRepository<Device>
    {
        Device GetDevices();
    }
}
