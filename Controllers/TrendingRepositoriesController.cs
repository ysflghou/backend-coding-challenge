using backend_coding_challenge.GithubClient;
using backend_coding_challenge.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace backend_coding_challenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrendingRepositoriesController : ControllerBase
    {
        private readonly ITrendingRepositoriesClient trendingRepositoriesClient;

        public TrendingRepositoriesController(ITrendingRepositoriesClient trendingRepositoriesClient)
        {
            this.trendingRepositoriesClient = trendingRepositoriesClient;
        }

        [HttpGet("/TrendingRepositories")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GithubRepositories))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTrendingRepositories()
        {
            try
            {
                GithubRepositories trendingRepositories = await trendingRepositoriesClient.GetTrendingReposAsync();
                return Ok(trendingRepositories);
            }
            catch(Exception e)
            {
                return NotFound(e);
            }
        }
    }
}
