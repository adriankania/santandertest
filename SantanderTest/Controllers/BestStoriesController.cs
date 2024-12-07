using Microsoft.AspNetCore.Mvc;
using SantanderTest.Model;
using SantanderTest.Services;

namespace SantanderTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BestStoriesController : Controller
    {
        private readonly IBestStoriesService _bestStoriesService;
        public BestStoriesController(IBestStoriesService bestStoriesService)
        {
            _bestStoriesService = bestStoriesService;
        }

        [HttpGet(Name = "GetBestStories")]
        public async Task<IEnumerable<BestStoryDto>> Get()
        {
            var ids = await _bestStoriesService.GetBestStoriesIdsAsync();
            var bestStoriesList = _bestStoriesService.GetBestStoriesList(ids);
            
            return bestStoriesList;
        }
    }
}
