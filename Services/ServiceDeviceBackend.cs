using System;
using System.Collections.Generic;
using System.Linq;
using DeviceManagementPortal.Domain.Entities;
using DeviceManagementPortal.Domain.Entities.DTOs;
using DeviceManagementPortal.Domain.Interfaces;

namespace DeviceManagementPortal.Services
{
    public class ServiceDeviceBackend : IServiceDeviceBackend
    {
        public List<DeviceBackend> List()
        {
            try
            {
                List<DeviceBackend> li_deviceBackends = new List<DeviceBackend>();
                using (var context = new DeviceManagementPortalContext())
                {
                    li_deviceBackends = context.DeviceBackend.ToList();
                }
                return li_deviceBackends;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DeviceBackend CreateDeviceBackend(DeviceBackendDTO _deviceBackendDTO)
        {
            try
            {
                DeviceBackend data = new DeviceBackend
                {
                    DeviceId = _deviceBackendDTO.DeviceId,
                    BackendId = _deviceBackendDTO.BackendId
                };
                using (var context = new DeviceManagementPortalContext())
                {
                    context.DeviceBackend.Add(data);
                    context.SaveChanges();
                }
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DeviceBackend UpdateDeviceBackend(DeviceBackendDTO _deviceBackendDTO)
        {
            try
            {
                DeviceBackend data = new DeviceBackend
                {
                    Id = _deviceBackendDTO.Id,
                    DeviceId = _deviceBackendDTO.DeviceId,
                    BackendId = _deviceBackendDTO.BackendId
                };
                using (var context = new DeviceManagementPortalContext())
                {
                    context.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int32 DeleteDeviceBackend(Int32 id)
        {
            try
            {                
                using (var context = new DeviceManagementPortalContext())
                {
                    context.Remove(context.DeviceBackend.Find(id));
                    context.SaveChanges();
                }
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}


