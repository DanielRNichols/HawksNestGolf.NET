using HawksNestGolf.NET.Shared.Interfaces.Repositories;
using HawksNestGolf.NET.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace HawksNestGolf.NET.Server.Controllers.Admin
{
    [ApiController]
    [Area("api")]
    [Route("[area]/[controller]")]
    public class TournamentsController : ControllerBase
    {
        private readonly ILogger<TournamentsController> _logger;
        private readonly ITournamentsRepository _repo;

        public TournamentsController(ILogger<TournamentsController> logger, ITournamentsRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IList<Tournament>>>> GetAll()
        {
            _logger.LogInformation("Getting tournaments");

            var items = await _repo.GetAll();

            var response = new ApiResponse<IList<Tournament>> { Data = items };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<Tournament>>> GetById(int id)
        {
            _logger.LogInformation("Getting bet with {id}", id);

            var item = await _repo.GetById(id);
            if (item is null)
                return NotFound();

            var response = new ApiResponse<Tournament> { Data = item };

            return BadRequest(response);
        }

    }
}