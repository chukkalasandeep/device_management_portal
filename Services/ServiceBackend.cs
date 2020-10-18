using System;
using System.Collections.Generic;
using System.Linq;
using DeviceManagementPortal.Domain.Entities;
using DeviceManagementPortal.Domain.Entities.DTOs;
using DeviceManagementPortal.Domain.Interfaces;

namespace DeviceManagementPortal.Services
{
    public class ServiceBackend : IServiceBackend
    {
        public List<Backend> List()
        {
            try
            {
                List<Backend> li_backends = new List<Backend>();
                using (var context = new DeviceManagementPortalContext())
                {
                    li_backends = context.Backend.ToList();
                }
                return li_backends;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Backend CreateBackend(BackendDTO _backendDTO)
        {
            try
            {
                Backend data = new Backend
                {
                    Name = _backendDTO.Name,
                    Address = _backendDTO.Address
                };
                using (var context = new DeviceManagementPortalContext())
                {

                    context.Backend.Add(data);
                    context.SaveChanges();
                }
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Backend UpdateBackend(BackendDTO _backendDTO)
        {
            try
            {
                Backend data = new Backend
                {
                    Id = _backendDTO.Id,
                    Name = _backendDTO.Name,
                    Address = _backendDTO.Address
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

        public Int32 DeleteBackend(Int32 id)
        {
            try
            {
                
                using (var context = new DeviceManagementPortalContext())
                {
                    context.Remove(context.Backend.Find(id));
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


