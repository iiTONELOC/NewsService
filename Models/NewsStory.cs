using MongoDB.Bson;
using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace NewsService.Models
{
    // ___ Interfaces ___
    public interface INewsApiStory
    {
        public string? Url { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Content { get; set; }
        public string? UrlToImage { get; set; }
        public string? Description { get; set; }
        public string? PublishedAt { get; set; }
        public Dictionary<string, string>? Source { get; set; }
    }

    public interface ICurrentsApiStory
    {
        public string? Url { get; set; }
        public string? Title { get; set; }
        public string? Image { get; set; }
        public string? Author { get; set; }
        public string? Language { get; set; }
        public string? published { get; set; }
        public string[]? Category { get; set; }
        public string? Description { get; set; }
    }

    public interface INewsStoryModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        // MONGO DB ID
        public string? _Id { get; set; }
        // NEWS API ONLY
        public string? Content { get; set; }
        // CURRENTS API ONLY
        public string? Language { get; set; }
        // CURRENTS API ONLY
        public string[]? Category { get; set; }
        public string? Url { get; set; }
        // NEWS API ONLY
        public Dictionary<string, string>? Source { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? UrlToImage { get; set; }
        public string? PublishedAt { get; set; }
        public string? Description { get; set; }
    }

    // ___ Classes ___

    public class NewsApiStory : INewsApiStory
    {
        public string? Url { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Content { get; set; }
        public string? UrlToImage { get; set; }
        public string? Description { get; set; }
        public string? PublishedAt { get; set; }
        public Dictionary<string, string>? Source { get; set; }
    }

    public class CurrentsApiStory : ICurrentsApiStory
    {
        public string? Id { get; set; }
        public string? Url { get; set; }
        public string? Title { get; set; }
        public string? Image { get; set; }
        public string? Author { get; set; }
        public string? Language { get; set; }
        public string? published { get; set; }
        public string[]? Category { get; set; }
        public string? Description { get; set; }
    }

    // __ MONGO DB MODEL __
    public class NewsStoryModel : INewsStoryModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        // MONGO DB ID
        [BsonElement("_id")]
        [JsonPropertyName("_id")]
        public string? _Id { get; set; }
        // NEWS API ONLY
        [BsonElement("content")]
        [JsonPropertyName("content")]
        public string? Content { get; set; }
        // CURRENTS API ONLY
        [BsonElement("story_id")]
        [JsonPropertyName("story_id")]
        public string? Story_id { get; set; }
        // CURRENTS API ONLY
        [BsonElement("language")]
        [JsonPropertyName("language")]
        public string? Language { get; set; }
        // CURRENTS API ONLY
        [BsonElement("category")]
        [JsonPropertyName("category")]
        public string[]? Category { get; set; }
        [BsonElement("url")]
        [JsonPropertyName("url")]
        public string? Url { get; set; } = null!;
        // NEWS API ONLY
        [BsonElement("source")]
        [JsonPropertyName("source")]
        public Dictionary<string, string>? Source { get; set; }
        [BsonElement("title")]
        [JsonPropertyName("title")]
        public string? Title { get; set; } = null!;
        [BsonElement("author")]
        [JsonPropertyName("author")]
        public string? Author { get; set; } = null!;
        [BsonElement("urlToImage")]
        [JsonPropertyName("urlToImage")]
        public string? UrlToImage { get; set; } = null!;
        [BsonElement("publishedAt")]
        [JsonPropertyName("publishedAt")]
        public string? PublishedAt { get; set; } = null!;
        [BsonElement("description")]
        [JsonPropertyName("description")]
        public string? Description { get; set; } = null!;
    }
}
