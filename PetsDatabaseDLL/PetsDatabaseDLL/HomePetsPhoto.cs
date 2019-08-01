using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsDatabaseDLL
{
    public class HomePetsPhoto
    {
        public int ID { get; set; }
        public string Photo { get; set; }
        [ForeignKey("homePets")]
        public int homePetsID { get; set; }
        public virtual HomePets homePets { get; set; }

    }
}
