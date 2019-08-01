using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsDatabaseDLL
{
    public class Clients
    {
        public int ID { get; set; }
        [ForeignKey("user")]
        public string UserID { get; set; }
        public virtual ApplicationUser user { get; set; }
        public virtual ICollection<Animals> animals { get; set; } = new List<Animals>();
        
    }
}
