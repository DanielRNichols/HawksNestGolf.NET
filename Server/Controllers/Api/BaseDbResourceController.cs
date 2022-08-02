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

        /// <summary>
        /// GetAll Items
        /// </summary>
        /// <param name="includeRelated"></param>
        /// <param name="orderBy"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        [HttpGet]
        public virtual async Task<ActionResult<ApiResponse<IList<T>>>> GetAll(bool includeRelated = true, string? orderBy = "", int skip = 0, int take = 0)
        {
            _logger.LogInformation("GetAll {type}", nameof(T));

            var queryOptions = new QueryOptions
            {
                IncludeRelated = includeRelated,
                OrderBy = QueryOptions.SortOptionsFromQueryString(orderBy),
                Skip = skip,
                Take = take
            };

            var items = await _repo.GetAll(queryOptions);
            var response = new ApiResponse<IList<T>> { Data = items };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<T>> GetById(int id, bool includeRelated = true)
        {
            _logger.LogInformation("GetById {type}", nameof(T));
            var item = await _repo.GetById(id, includeRelated);
            if (item == null)
                return NotFound();

            var response = new ApiResponse<T> { Data = item };

            return Ok(response);
        }
    }
}
