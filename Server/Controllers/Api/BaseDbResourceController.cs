using HawksNestGolf.NET.Shared.Interfaces.Repositories;
using HawksNestGolf.NET.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HawksNestGolf.NET.Server.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseDbResourceController<T> : ControllerBase where T : class, IDbResource, new()
    {
        private readonly ILogger _logger;
        private readonly IBaseDbResourceRepository<T> _repo;

        public BaseDbResourceController(ILogger logger, IBaseDbResourceRepository<T> repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpGet]
        public virtual async Task<ActionResult<ApiResponse<IList<T>>>> GetAll()
        {
            _logger.LogInformation("GetAll {type}", nameof(T));
            var items = await _repo.GetAll();
            var response = new ApiResponse<IList<T>> { Data = items };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<T>> GetById(int id)
        {
            _logger.LogInformation("GetById {type}", nameof(T));
            var item = await _repo.GetById(id);
            if (item == null)
                return NotFound();

            var response = new ApiResponse<T> { Data = item };

            return Ok(response);
        }
    }
}
