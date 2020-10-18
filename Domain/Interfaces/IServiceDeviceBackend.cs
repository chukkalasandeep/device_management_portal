using System;
using System.Collections.Generic;
using DeviceManagementPortal.Domain.Entities;
using DeviceManagementPortal.Domain.Entities.DTOs;

namespace DeviceManagementPortal.Domain.Interfaces
{
    public interface IServiceDeviceBackend
    {
        List<DeviceBackend> List();
        DeviceBackend CreateDeviceBackend(DeviceBackendDTO _deviceBackendDTO);
        DeviceBackend UpdateDeviceBackend(DeviceBackendDTO _deviceBackendDTO);
        Int32 DeleteDeviceBackend(Int32 id);
    }
}

