using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsDatabaseDLL
{
    public class Posts
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public int Likes { get; set; }
        [DataType("Date")]
        public DateTime PostDateTime { get; set; }
        [ForeignKey("User")]
        public string UserID { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Comments> Comments { get; set; } = new List<Comments>();
        public virtual ICollection<PostPhotos> PostPhotos { get; set; } = new List<PostPhotos>();
        public virtual ICollection<UserLikes> UserLikes { get; set; } = new List<UserLikes>();

    }
}
