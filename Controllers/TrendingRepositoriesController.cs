using backend_coding_challenge.GithubClient;
using backend_coding_challenge.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

        [HttpGet("/LanguagesInTrendingRepositories")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProgrammingLanguages))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTrendingRepositories()
        {
            try
            {
                GithubRepositories trendingRepositories = await trendingRepositoriesClient.GetTrendingReposAsync();
                ProgrammingLanguages programmingLanguages = ProgrammingLanguagesBuilder
                    .BuildProgrammingLanguagesInTrendingRepositories(trendingRepositories);
                return Ok(programmingLanguages);
            }
            catch(Exception e)
            {
                return NotFound(e);
            }
        }
    }
}
