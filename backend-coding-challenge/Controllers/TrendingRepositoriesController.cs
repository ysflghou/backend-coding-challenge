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

        /// <summary>
        /// Returns the languages used in the trending github repositores for the last 30 days
        /// with the number and the list of repositories used in each language.
        /// In case of any exception, the api returns a NotFound result with the exception object
        /// </summary>
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
                return NotFound($"Failed to get the trending repositories, original error message: {e.Message}");
            }
        }
    }
}
