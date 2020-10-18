using System;
using System.Collections.Generic;
using DeviceManagementPortal.Domain.Entities;
using DeviceManagementPortal.Domain.Entities.DTOs;

namespace DeviceManagementPortal.Domain.Interfaces
{
    public interface IServiceBackend
    {
        List<Backend> List();
        Backend CreateBackend(BackendDTO _backendDTO);
        Backend UpdateBackend(BackendDTO _backendDTO);
        Int32 DeleteBackend(Int32 id);
    }
}

