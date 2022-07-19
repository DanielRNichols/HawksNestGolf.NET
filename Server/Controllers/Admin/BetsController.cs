using HawksNestGolf.NET.Shared.Interfaces.Repositories;
using HawksNestGolf.NET.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace HawksNestGolf.NET.Server.Controllers.Admin
{
    [ApiController]
    [Area("api")]
    [Route("[area]/[controller]")]
    public class BetsController : ControllerBase
    {
        private readonly ILogger<BetsController> _logger;
        private readonly IBetsRepository _repo;

        public BetsController(ILogger<BetsController> logger, IBetsRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IList<Bet>>>> GetAll()
        {
            _logger.LogInformation("Getting bets");

            var bets = await _repo.GetAll();

            var response = new ApiResponse<IList<Bet>> { Data = bets };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<Bet>>> GetById(int id)
        {
            _logger.LogInformation("Getting bet with {id}", id);

            var bet = await _repo.GetById(id);
            if (bet is null)
                return NotFound();

            var response = new ApiResponse<Bet> { Data = bet };

            return BadRequest(response);
        }

    }
}