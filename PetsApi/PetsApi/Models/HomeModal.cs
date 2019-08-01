using PetsDatabaseDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetsApi.Models
{
    public class HomeModal
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public int AvailablePlace { get; set; }
        public int NumberOfRooms { get; set; }
        public decimal PriceForNight { get; set; }

        public virtual List<string> HomePhotos { get; set; } = new List<string>();
        public virtual user User { get; set; } = new user();
    }
}