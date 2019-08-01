using PetsDatabaseDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetsApi.Models
{
    public class AnimalModel
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int age { get; set; }
        public string Description { get; set; }
        public virtual string category { get; set; }
        public virtual List<string> AnimalPhotos { get; set; } = new List<string>();
        public virtual user user { get; set; } = new user();



    }
}