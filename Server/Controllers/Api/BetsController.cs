using HawksNestGolf.NET.Shared.Interfaces.Repositories;
using HawksNestGolf.NET.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace HawksNestGolf.NET.Server.Controllers.Api
{
    [ApiController]
    [Area("api")]
    [Route("[area]/[controller]")]
    public class BetsController : BaseDbResourceController<Bet>
    {
        public BetsController(ILogger<BetsController> logger, IBetsRepository repo) : base(logger, repo)
        {
        }

        /// <summary>
        /// Get All Bets
        /// </summary>
        /// <remarks>
        /// Document orderby here
        /// </remarks>
        [HttpGet]
        public override Task<ActionResult<ApiResponse<IList<Bet>>>> GetAll(bool includeRelated = true, string? orderBy = "", int skip = 0, int take = 0)
        {
            return base.GetAll(includeRelated, orderBy, skip, take);
        }
    }
}