using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
    public class DeviceController : ControllerBase
    {
        private readonly IServiceDevice _serviceDevice;
        private readonly ILogger<DeviceController> _logger;

        public DeviceController(IServiceDevice serviceDevice, ILogger<DeviceController> logger)
        {
            _serviceDevice = serviceDevice;
            _logger = logger;

        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var data = _serviceDevice.List();                
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError("Device>Get: error occured- "+ ex.Message, ex);
                return BadRequest(ex);
            }
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Int32 id)
        {
            try
            {
                var data = _serviceDevice.List().Where(i=>i.Id==id);                

                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError("Device>Get(id): error occured- " + ex.Message, ex);
                return BadRequest(ex);
            }
        }
        

        [HttpPost]        
        public IActionResult Post([FromBody] DeviceDTO _deviceDTO)
        {
            try
            {
                var data = _serviceDevice.CreateDevice(_deviceDTO);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut]
        public IActionResult Put([FromBody] DeviceDTO _deviceDTO)
        {
            try
            {
                var data = _serviceDevice.UpdateDevice(_deviceDTO);

                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError("Device>Put: error occured- " + ex.Message, ex);
                return BadRequest(ex);
            }
        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete(Int32 id)
        {
            try
            {
                var data = _serviceDevice.DeleteDevice(id);

                return Ok(id);
            }
            catch (Exception ex)
            {
                _logger.LogError("Device>Delete: error occured- " + ex.Message, ex);
                return BadRequest(ex);
            }
        }
    }
}