using Microsoft.AspNetCore.Mvc;
using NewsService.Services;
using NewsService.Models;

namespace NewsService.Controllers

{
    [ApiController]
    [Route("/latest-news")]
    public class NewsServiceController : ControllerBase
    {
        private readonly ILogger<NewsServiceController> _logger;
        private readonly NewsStoryService _newsStoryService;

        public NewsServiceController(NewsStoryService newsStoryService, ILogger<NewsServiceController> logger)
        {
            _newsStoryService = newsStoryService;
            _logger = logger;
        }


        [HttpGet]
        public async Task<List<NewsStoryModel>> Get() =>
            await _newsStoryService.GetAsync();
    }
}