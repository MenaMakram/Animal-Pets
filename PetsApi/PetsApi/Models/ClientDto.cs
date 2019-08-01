using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetsApi.Models
{
    public class ClientDto
    {
        public List<AnimalDto> Animals { get; set; } = new List<AnimalDto>();
    }
    public class AnimalDto
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int age { get; set; }
        public bool status { get; set; }
        public int MarriedCount { get; set; }
        public string Description { get; set; }
        public int SonsCount { get; set; }
        public decimal MarriedSalary { get; set; }
        public bool AvailableMarried { get; set; }
        public bool AvailableForBill { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public List<AnimalPhotoDto> animalPhoto { get; set; } = new List<AnimalPhotoDto>();
    }
    public class AnimalPhotoDto
    {
        public int ID { get; set; }
        public string Image { get; set; }
    }

}