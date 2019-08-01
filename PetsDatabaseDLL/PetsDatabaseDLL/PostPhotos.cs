using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsDatabaseDLL
{
    public class PostPhotos
    {
        public int ID { get; set; }
        public string Image { get; set; }
        [ForeignKey("Posts")]
        public int? PostID { get; set; }
        public virtual Posts Posts { get; set; }
    }
}
