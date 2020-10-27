using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DeviceManagementPortal.Domain.Entities.DTOs;
using DeviceManagementPortal.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace DeviceManagementPortal.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class DeviceBackendController : ControllerBase
    {
        private readonly IServiceDeviceBackend _serviceDeviceBackend;
        private readonly IServiceDevice _serviceDevice;
        private readonly IServiceBackend _serviceBackend;
        private readonly ILogger<DeviceBackendController> _logger;
        public DeviceBackendController(IServiceDeviceBackend serviceDeviceBackend, IServiceDevice serviceDevice, IServiceBackend serviceBackend, ILogger<DeviceBackendController> logger)
        {
            _serviceDeviceBackend = serviceDeviceBackend;
            _serviceDevice = serviceDevice;
            _serviceBackend = serviceBackend;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var mappings = _serviceDeviceBackend.List();
                var devices = _serviceDevice.List();
                var backends = _serviceBackend.List();
                var data = (from db in mappings
                            join d in devices on db.DeviceId equals d.Id
                            join b in backends on db.BackendId equals b.Id
                            select new { Id = db.Id, DeviceId = db.DeviceId, BackendId = db.BackendId, Imei = d.Imei, BackendName = b.Name }).ToList();
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError("DeviceBackend>Get: error occured- " + ex.Message, ex);
                return BadRequest(ex);
            }
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Int32 id)
        {
            try
            {
                var mappings = _serviceDeviceBackend.List().Where(i => i.Id == id);
                var devices = _serviceDevice.List().Where(i => i.Id == id);
                var backends = _serviceBackend.List();
                var data = (from db in mappings
                            join d in devices on db.DeviceId equals d.Id
                            join b in backends on db.BackendId equals b.Id
                            select new { Id = db.Id, DeviceId = db.DeviceId, BackendId = db.BackendId, Imei = d.Imei, BackendName = b.Name }).ToList();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpPost]
        public IActionResult Post([FromBody] DeviceBackendDTO _deviceBackendDTO)
        {
            try
            {
                var data = _serviceDeviceBackend.CreateDeviceBackend(_deviceBackendDTO);

                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError("DeviceBackend>Get(id): error occured- " + ex.Message, ex);
                return BadRequest(ex);
            }
        }
        [HttpPut]
        public IActionResult Put([FromBody] DeviceBackendDTO _deviceBackendDTO)
        {
            try
            {
                var data = _serviceDeviceBackend.UpdateDeviceBackend(_deviceBackendDTO);

                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError("DeviceBackend>Put: error occured- " + ex.Message, ex);
                return BadRequest(ex);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(Int32 id)
        {
            try
            {
                var data = _serviceDeviceBackend.DeleteDeviceBackend(id);

                return Ok(id);
            }
            catch (Exception ex)
            {
                _logger.LogError("DeviceBackend>Delete: error occured- " + ex.Message, ex);
                return BadRequest(ex);
            }
        }
    }
}