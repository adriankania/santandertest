using System.Collections.Concurrent;
using SantanderTest.Model;

namespace SantanderTest.Services
{
    public class BestStoriesService : IBestStoriesService
    {
        //https://hacker-news.firebaseio.com/v0/beststories.json
        private static HttpClient httpClient = new()
        {
            BaseAddress = new Uri("https://hacker-news.firebaseio.com"),
        };

        public async Task<IEnumerable<int>> GetBestStoriesIdsAsync()
        {
            var response = await httpClient.GetAsync("/v0/beststories.json");
            var ids = await response.Content.ReadFromJsonAsync<IEnumerable<int>>();

            return ids;
        }

        public IEnumerable<BestStoryDto> GetBestStoriesList(IEnumerable<int> storyIds)
        {
            ConcurrentBag<BestStoryResponse> tempData = new ConcurrentBag<BestStoryResponse>();
            var options = new ParallelOptions { MaxDegreeOfParallelism = 10 };

            Parallel.ForEach(storyIds, options, storyId =>
            {
                var story = Get(storyId);
                tempData.Add(story);
            });

            var bestStories = from story in tempData
                              orderby story.Score
                              select new BestStoryDto()
                              {
                                  Title = story.Title,
                                  Uri = story.Url,
                                  PostedBy = story.PostedBy,
                                  Time = new DateTime(story.Time).ToString(),
                                  Score = story.Score,
                                  CommentCount = story.Descendants
                              };

            return bestStories;
        }

        private BestStoryResponse Get(int storyId)
        {
            var url = $"/v0/item/{storyId}.json";
            var response = httpClient.GetAsync(url).Result;
            var json = response.Content.ReadFromJsonAsync<BestStoryResponse>().Result;

            return json;
        }
    }
}
