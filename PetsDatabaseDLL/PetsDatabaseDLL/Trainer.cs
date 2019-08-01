using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsDatabaseDLL
{
    public class Trainer
    {
        public int ID { get; set; }
        public string JobTitle { get; set; }
        public string Overview { get; set; }
        public string Courses { get; set; }
        public string TrainePlace { get; set; }
        [DataType("money")]
        public decimal PricePerHour { get; set; }
        [ForeignKey("user")]
        public string UserID { get; set; }
        public virtual ApplicationUser user { get; set; }
        
    }
}
