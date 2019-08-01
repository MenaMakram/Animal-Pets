using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetsApi.Models
{
    public class HomePetDto
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public int AvailablePlace { get; set; }
        public int NumberOfRooms { get; set; }
        public decimal PriceForNight { get; set; }
        public List<HomePetsPhotoDTo> photos { get; set; } = new List<HomePetsPhotoDTo>();
    }
    public class HomePetsPhotoDTo
    {
        public int ID { get; set; }
        public string Photo { get; set; }
    }
}