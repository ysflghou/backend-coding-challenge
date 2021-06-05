using backend_coding_challenge.Models;
using System.Threading.Tasks;

namespace backend_coding_challenge.GithubClient
{
    public interface ITrendingRepositoriesClient
    {
        public Task<GithubRepositories> GetTrendingReposAsync();
    }
}
