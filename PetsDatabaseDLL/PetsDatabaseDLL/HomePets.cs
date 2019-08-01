using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsDatabaseDLL
{
    public class HomePets
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public int AvailablePlace { get; set; }
        public int NumberOfRooms { get; set; }
        [DataType("money")]
        public decimal PriceForNight { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public virtual ICollection<HomePetsPhoto> homePetsPhoto { get; set; } = new List<HomePetsPhoto>();


    }
}
