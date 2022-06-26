using System.Text.Json;
using WebApplication2.Controllers;

namespace WebApplication2.Services
{
    public class Service
    {
        public const string requestUri = "https://graphql.anilist.co/";
    }

    public class HomeService
    {
        public static async Task<Character[]> Deserialization(HttpResponseMessage a)
        {
            var response = await a.Content.ReadAsStringAsync();
            var deserializationResult = JsonSerializer.Deserialize<GqlRequest>(response);
            var characters = deserializationResult!.data.Page.characters;
            
            return characters;
        }
    }
}
