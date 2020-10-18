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
        private readonly ILogger<DeviceBackendController> _logger;
        public DeviceBackendController(IServiceDeviceBackend serviceDeviceBackend, ILogger<DeviceBackendController> logger)
        {
            _serviceDeviceBackend = serviceDeviceBackend;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var data = _serviceDeviceBackend.List();

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
                var data = _serviceDeviceBackend.List().Where(i=>i.Id==id);                

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