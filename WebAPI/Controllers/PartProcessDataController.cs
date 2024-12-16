using AutoMapper;
using BL.DTOs;
using BL.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/part")]
    public class PartProcessDataController : ControllerBase
    {
        private readonly ILogger<PartProcessDataController> _logger;
        private readonly IMapper _mapper;

        public PartProcessDataController(ILogger<PartProcessDataController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetPartsProcessData")]
        public async Task<ActionResult<List<PartAllProcessDataDTO>>> GetPartsProcessData([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10, [FromQuery] DateTime? startedFrom = null, [FromQuery] DateTime? startedTo = null)
        {
            PartProcessDataServices partProcessDataServices = new PartProcessDataServices(_mapper);
            return Ok(await partProcessDataServices.GetPartsProcessData(pageNumber, pageSize, startedFrom, startedTo));
        }

        [HttpGet("{partId}", Name = "GetPartProcessData")]
        public async Task<ActionResult<PartAllProcessDataDTO>> GetPartProcessData([FromRoute] int partId)
        {
            PartProcessDataServices partProcessDataServices = new PartProcessDataServices(_mapper);
            PartAllProcessDataDTO? partAllProcessData = await partProcessDataServices.GetPartProcessData(partId);

            if (partAllProcessData != null)
            {
                return Ok(partAllProcessData);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
