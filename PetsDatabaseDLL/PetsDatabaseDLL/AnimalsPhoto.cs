using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsDatabaseDLL
{
    public class AnimalsPhoto
    {
        public int ID { get; set; }
        public string Image { get; set; }
        [ForeignKey("Animal")]
        public int? AnimalID { get; set; }
        public virtual Animals Animal { get; set; }
    }
}
