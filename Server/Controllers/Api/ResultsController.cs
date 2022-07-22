using HawksNestGolf.NET.Shared.Interfaces.Repositories;
using HawksNestGolf.NET.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HawksNestGolf.NET.Server.Controllers.Api
{
    [Area("api")]
    [Route("[area]/[controller]")]
    [ApiController]
    public class ResultsController : BaseDbResourceController<Result>
    {
        public ResultsController(ILogger<ResultsController> logger, IResultsRepository repo) : base(logger, repo)
        {
        }

    }
}
