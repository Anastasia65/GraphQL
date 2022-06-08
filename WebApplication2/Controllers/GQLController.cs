using Microsoft.AspNetCore.Mvc;


namespace WebApplication2.Controllers
{

    public class GqlRequest
    {
        public Data data { get; set; }
    }

    public class Data
    {
        public Character Character { get; set; }
    }

    public class Character
    {
        public int id { get; set; }
        public Name name { get; set; }
        public string gender { get; set; }
        public Dateofbirth dateOfBirth { get; set; }
        public string age { get; set; }
        public object bloodType { get; set; }
        public string siteUrl { get; set; }
    }

    public class Name
    {
        public string full { get; set; }
    }

    public class Dateofbirth
    {
        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; }
    }

    [ApiController]
    [Route(template: "[controller]")]
    public class GQLController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GQLController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet(template: "", Name = nameof(GetAllCharacters))]

        public async Task<Character> GetAllCharacters()
        {
            var client = _httpClientFactory.CreateClient(name: "gql");
            var query = new { query = "{ Character (id:1){id,name{full},gender,dateOfBirth{year month day},age,bloodType,siteUrl}}" };
            var a = await client
                .PostAsJsonAsync(requestUri: "https://graphql.anilist.co/", value: query);
            var result = await a.Content.ReadFromJsonAsync<GqlRequest>();
            return result.data?.Character ?? new Character {};
        }
    }
}
