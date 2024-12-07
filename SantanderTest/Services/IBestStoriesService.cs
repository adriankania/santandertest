using SantanderTest.Model;

namespace SantanderTest.Services
{
    public interface IBestStoriesService
    {
        public Task<IEnumerable<int>> GetBestStoriesIdsAsync();
        public IEnumerable<BestStoryDto> GetBestStoriesList(IEnumerable<int> storyIds);
    }
}
