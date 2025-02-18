using BL.DTOs;
using BL.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/station")]
    public class StationStatusController : ControllerBase
    {
        private readonly ILogger<StationStatusController> _logger;

        public StationStatusController(ILogger<StationStatusController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetStationsStatus")]
        public async Task<ActionResult<List<StationStatusDTO>>> GetStationsStatus()
        {
            StationStatusServices stationStatusServices = new StationStatusServices();
            return Ok(await stationStatusServices.GetStationsStatus());
        }

        [HttpGet("{stationId}", Name = "GetStationStatus")]
        public async Task<ActionResult<StationStatusDTO>> GetStationStatus([FromRoute] int stationId)
        {
            StationStatusServices stationStatusServices = new StationStatusServices();
            StationStatusDTO? stationStatus = await stationStatusServices.GetStationStatus(stationId);

            if (stationStatus != null)
            {
                return Ok(stationStatus);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
