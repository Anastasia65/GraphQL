using WebApplication2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
<<<<<<< HEAD

=======
using Newtonsoft.Json;
>>>>>>> 676cad7658ee381a62600754ec2cca80a967b774

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
                .PostAsJsonAsync(requestUri: "https://graphql.anilist.co/", value: query);
<<<<<<< HEAD
            var response = await a.Content.ReadAsStringAsync();
            var deserializationResult = JsonSerializer.Deserialize<GqlRequest>(response);
            var characters = deserializationResult!.data.Page.characters;
            return View(characters);
        }

=======
            var result = await a.Content.ReadFromJsonAsync<GqlRequest>();//await a.Content.ReadAsStringAsync();
            //Deserialization(result);
            var sh = result.data?.Page?.characters ?? new Character { };

            return View(sh);
        }

        //private void Deserialization(string result)
        //{
        //    var people = JsonConvert.DeserializeObject <List<Character>>(result);
        //    return;
        //}
>>>>>>> 676cad7658ee381a62600754ec2cca80a967b774

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
