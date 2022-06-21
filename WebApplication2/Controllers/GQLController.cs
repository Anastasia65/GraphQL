using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class GqlRequest
    {
        public Data data { get; set; }
    }
    public class Data
    {
        public Page Page { get; set; }
    }
    public class Page
    {
        public Character[] characters { get; set; }
    }

    public class Character
    {
        public int id { get; set; }
        public Name name { get; set; }
        public string gender { get; set; }
        public Dateofbirth dateOfBirth { get; set; }
        public string age { get; set; }
        public string siteUrl { get; set; }
        public string description { get; set; }
    }

    public class Name
    {
        public string full { get; set; }
    }

    public class Dateofbirth
    {
        public int? year { get; set; }
        public int? month { get; set; }
        public int? day { get; set; }
    }
}
