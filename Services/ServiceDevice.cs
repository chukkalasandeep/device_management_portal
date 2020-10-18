using System;
using System.Collections.Generic;
using System.Linq;
using DeviceManagementPortal.Domain.Entities;
using DeviceManagementPortal.Domain.Entities.DTOs;
using DeviceManagementPortal.Domain.Interfaces;

namespace DeviceManagementPortal.Services
{
    public class ServiceDevice : IServiceDevice
    {
        public List<Device> List()
        {
            try
            {
                List<Device> li_devices = new List<Device>();
                using (var context = new DeviceManagementPortalContext())
                {
                    li_devices = context.Device.ToList();
                }
                return li_devices;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Device CreateDevice(DeviceDTO _deviceDTO)
        {
            try
            {
                Device data = new Device
                {
                    Imei = _deviceDTO.Imei,
                    SimCardNumber = _deviceDTO.SimCardNumber,
                    Enabled = _deviceDTO.Enabled,
                    Created = DateTime.Now,
                    CreatedBy = _deviceDTO.CreatedBy
                };
                using (var context = new DeviceManagementPortalContext())
                {

                    context.Device.Add(data);
                    context.SaveChanges();
                }
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Device UpdateDevice(DeviceDTO _deviceDTO)
        {
            try
            {
                Device data = new Device
                {
                    Id = _deviceDTO.Id,
                    Imei = _deviceDTO.Imei,
                    SimCardNumber = _deviceDTO.SimCardNumber,
                    Enabled = _deviceDTO.Enabled,
                    Created = _deviceDTO.Created,
                    CreatedBy = _deviceDTO.CreatedBy
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

        public Int32 DeleteDevice(Int32 id)
        {
            try
            {
                
                using (var context = new DeviceManagementPortalContext())
                {
                    context.Remove(context.Device.Find(id));
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


