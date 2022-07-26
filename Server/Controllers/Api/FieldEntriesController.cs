using HawksNestGolf.NET.Shared.Interfaces.Repositories;
using HawksNestGolf.NET.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HawksNestGolf.NET.Server.Controllers.Api
{
    [Area("api")]
    [Route("[area]/[controller]")]
    [ApiController]
    public class FieldEntriesController : BaseDbResourceController<FieldEntry>
    {
        public FieldEntriesController(ILogger<FieldEntriesController> logger, IFieldEntriesRepository repo) : base(logger, repo)
        {
        }

    }
}
