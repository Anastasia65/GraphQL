using WebApplication2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }
        
        private readonly IHttpClientFactory _httpClientFactory;
        public async Task<IActionResult> Index()
        {
                var client = _httpClientFactory.CreateClient(name: "gql");
                var query = new { query = "query {Page(page: 1){characters(id_in: [1,2,3,4,5,6,7]){id name {full} gender dateOfBirth {year month day} age siteUrl}}}" };
                var a = await client
                    .PostAsJsonAsync(Service.requestUri, value: query);
                var characters = HomeService.Deserialization(a);

            if (characters == null)
                throw new Exception("internal server error status code 500");
            else
                return View(characters.Result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}