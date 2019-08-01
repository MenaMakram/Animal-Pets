using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsDatabaseDLL
{
    public class UserLikes
    {
        public int ID { get; set; }
        [ForeignKey("Posts")]
        public int? PostId { get; set; }
        public virtual Posts Posts { get; set; }
        [ForeignKey("User")]
        public string UserID { get; set; }
        public bool Status { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}
