using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DeviceManagementPortal.Domain.Entities.DTOs;
using DeviceManagementPortal.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace DeviceManagementPortal.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class BackendController : ControllerBase
    {
        private readonly IServiceBackend _serviceBackend;
        private readonly ILogger<BackendController> _logger;
        public BackendController(IServiceBackend serviceBackend, ILogger<BackendController> logger)
            {
            _serviceBackend = serviceBackend;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var data = _serviceBackend.List();

                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError("Backend>Get: error occured- " + ex.Message, ex);
                return BadRequest(ex);
            }
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Int32 id)
        {
            try
            {
                var data = _serviceBackend.List().Where(i=>i.Id==id);                

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        

        [HttpPost]       
        public IActionResult Post([FromBody] BackendDTO _backendDTO)
        {
            try
            {
                var data = _serviceBackend.CreateBackend(_backendDTO);

                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError("Backend>Get(id): error occured- " + ex.Message, ex);
                return BadRequest(ex);
            }
        }
        [HttpPut]
        public IActionResult Put([FromBody] BackendDTO _backendDTO)
        {
            try
            {
                var data = _serviceBackend.UpdateBackend(_backendDTO);

                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError("Backend>Put: error occured- " + ex.Message, ex);
                return BadRequest(ex);
            }
        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete(Int32 id)
        {
            try
            {
                var data = _serviceBackend.DeleteBackend(id);

                return Ok(id);
            }
            catch (Exception ex)
            {
                _logger.LogError("Backend>Delete: error occured- " + ex.Message, ex);
                return BadRequest(ex);
            }
        }
    }
}