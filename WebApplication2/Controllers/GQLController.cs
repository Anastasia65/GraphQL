<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Mvc;
=======
using Microsoft.AspNetCore.Mvc;
>>>>>>> 676cad7658ee381a62600754ec2cca80a967b774

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
<<<<<<< HEAD
        public Character[] characters { get; set; }
=======
        public Character characters { get; set; }
>>>>>>> 676cad7658ee381a62600754ec2cca80a967b774
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
<<<<<<< HEAD
        public int? year { get; set; }
        public int? month { get; set; }
        public int? day { get; set; }
=======
        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; }
>>>>>>> 676cad7658ee381a62600754ec2cca80a967b774
    }
}
