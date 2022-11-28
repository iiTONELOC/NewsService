using NewsService.Models;
using MongoDB.Driver;

namespace NewsService.Services
{
    public class NewsStoryService
    {
        private readonly IMongoCollection<NewsStoryModel> _newsStories;

        public NewsStoryService()
        {
            var dbName = System.Environment
            .GetEnvironmentVariable("MONGO_DB") ?? "";

            var mongoUri = System.Environment
            .GetEnvironmentVariable("MONGO_URI") ?? "";

            var collection = System.Environment
            .GetEnvironmentVariable("MONGO_COLLECTION") ?? "";

            var client = new MongoClient(mongoUri);
            var database = client.GetDatabase(dbName);

            _newsStories = database.GetCollection<NewsStoryModel>(collection);
        }

        public async Task<List<NewsStoryModel>> GetAsync() =>
            await _newsStories.Find(newsStory => true).ToListAsync();

        public async Task<NewsStoryModel?> GetAsync(string id) =>
            await _newsStories
            .Find<NewsStoryModel>(newsStory => newsStory._Id == id)
            .FirstOrDefaultAsync();

        public async Task CreateAsync(NewsStoryModel newsStory) =>
            await _newsStories.InsertOneAsync(newsStory);

        public async Task UpdateAsync(string id, NewsStoryModel newsStoryIn) =>
            await _newsStories.ReplaceOneAsync(newsStory => newsStory._Id == id, newsStoryIn);

        public async Task RemoveAsync(string id) =>
            await _newsStories.DeleteOneAsync(newsStory => newsStory._Id == id);
    }
}
