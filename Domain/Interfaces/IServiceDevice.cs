using System;
using System.Collections.Generic;
using DeviceManagementPortal.Domain.Entities;
using DeviceManagementPortal.Domain.Entities.DTOs;

namespace DeviceManagementPortal.Domain.Interfaces
{
    public interface IServiceDevice
    {
        List<Device> List();
        Device CreateDevice(DeviceDTO _deviceDTO);
        Device UpdateDevice(DeviceDTO _deviceDTO);
        Int32 DeleteDevice(Int32 id);
    }
}

