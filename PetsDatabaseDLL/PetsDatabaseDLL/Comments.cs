using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsDatabaseDLL
{
    public class Comments
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public DateTime CommentDateTime { get; set; }
        [ForeignKey("user")]
        public string UserId { get; set; }
        public virtual ApplicationUser user { get; set; }
        [ForeignKey("posts")]
        public int? PostID { get; set; }
        public virtual Posts posts { get; set; }

    }
}
