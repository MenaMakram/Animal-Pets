using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetsApi.Models
{
    public class TrainerDto
    {
        public int ID { get; set; }
        public string JobTitle { get; set; }
        public string Overview { get; set; }
        public string Courses { get; set; }
        public string TrainePlace { get; set; }
        public decimal PricePerHour { get; set; }
        public virtual user user { get; set; } = new user();

    }
}